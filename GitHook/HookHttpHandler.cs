using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Routing;
using GitHookController.Exceptions;
using GitHookController.Models;
using Newtonsoft.Json;

namespace GitHookController
{
    public class HookHttpHandler : IHttpHandler, IRouteHandler
    {
        const String GithubEventHeader = "X-GitHub-Event";
        const String GithubDeliveryHeader = "X-GitHub-Delivery";
        const String GithubSignatureHeader = "X-Hub-Signature";

        private readonly HookFactory _hookFactory;

        public bool IsReusable
        {
            get { return false; }
        }

        public HookHttpHandler()
            : this(new HookFactory())
        {

        }

        public HookHttpHandler(HookFactory hookFactory)
        {
            _hookFactory = hookFactory;
        }

        public void ProcessRequest(HttpContext context)
        {
            ProcessRequest(new HttpContextWrapper(context));
        }

        public void ProcessRequest(HttpContextBase context)
        {
            if (!context.Request.HttpMethod.Equals("POST", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new InvalidRequestTypeException(context.Request.Url);
            }
            var payloadRequest = context.Request["payload"];
            if (string.IsNullOrEmpty(payloadRequest))
            {
                payloadRequest = GetPayloadFromRequestBody(context);
            }
            if (string.IsNullOrEmpty(payloadRequest))
            {
                throw new InvalidPayloadException();
            }
            var model = JsonConvert.DeserializeObject<HookModel>(payloadRequest);
            if (model == null || model.repository == null || string.IsNullOrEmpty(model.repository.name))
            {
                throw new InvalidPayloadModelException();
            }

            model.EventName = context.Request.Headers.Get(GithubEventHeader);
            model.EventIdentifier = context.Request.Headers.Get(GithubDeliveryHeader);
            model.EventDigest = context.Request.Headers.Get(GithubSignatureHeader);

            var gitHook = _hookFactory.GetHook(model);
            gitHook.GetHook(model);
        }

        private string GetPayloadFromRequestBody(HttpContextBase context)
        {
            var body = context.Request.InputStream;
            var encoding = context.Request.ContentEncoding;
            using (var reader = new StreamReader(body, encoding))
            {
                return reader.ReadToEnd();
            }
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }
    }
}
