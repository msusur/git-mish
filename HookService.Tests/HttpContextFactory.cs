using System;
using System.Web;
using Moq;

namespace HookService.Tests
{
    public class HttpContextFactory
    {
        public static HttpContextBase Create(string fromUrl, string queryString, string jsonString = "", string httpMethod = "POST")
        {
            var mockContext = new Mock<HttpContextBase>();
            var mockRequest = new Mock<HttpRequestBase>();
            var mockResponse = new Mock<HttpResponseBase>();
            var mockSessionState = new Mock<HttpSessionStateBase>();
            var mockApplication = new Mock<HttpApplicationStateBase>();
            mockRequest.SetupGet(@base => @base.QueryString).Returns(HttpUtility.ParseQueryString(queryString));
            mockRequest.SetupGet(@base => @base.HttpMethod).Returns(httpMethod);
            mockRequest.SetupGet(@base => @base.Url).Returns(new Uri(FixUrl(fromUrl)));
            mockRequest.SetupGet(@base => @base[It.Is<string>(s => s.ToLowerInvariant().Equals("payload"))]).Returns(jsonString);

            mockContext.Setup(ctxt => ctxt.Request).Returns(mockRequest.Object);
            mockContext.Setup(ctxt => ctxt.Response).Returns(mockResponse.Object);
            mockContext.Setup(ctxt => ctxt.Session).Returns(mockSessionState.Object);
            mockContext.Setup(ctxt => ctxt.Application).Returns(mockApplication.Object);

            return mockContext.Object;
        }

        private static string FixUrl(string fromUrl)
        {
            if (!fromUrl.StartsWith("http://"))
            {
                return "http://" + fromUrl;
            }
            return fromUrl;
        }
    }
}