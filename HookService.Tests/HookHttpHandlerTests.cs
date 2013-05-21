using System;
using System.IO;
using System.Reflection;
using System.Resources;
using GitHookController;
using GitHookController.Exceptions;
using GitHookController.HookHandlers;
using GitHookController.Models;
using Moq;
using Xunit;

namespace HookService.Tests
{
    // ReSharper disable InconsistentNaming
    public class HookHttpHandlerTests
    {
        [Fact]
        public void Get_request_from_github_and_process_to_githook()
        {
            var handler = new HookHttpHandler();
            var context = HttpContextFactory.Create("github.com", "", GetTestJson("PayloadSample.json"));

            var hookHandler = new Mock<IHandler>();

            GitHook.SetupForRepository("testing").ThenRunInstance(hookHandler.Object).Save();

            handler.ProcessRequest(context);
            hookHandler.Verify(gitHook => gitHook.HandleHook(It.IsAny<HookModel>()), Times.Once());
        }

        [Fact]
        public void Get_requests_from_anywhere_throws_invalid_request_exception()
        {
            var handler = new HookHttpHandler(new HookFactory());
            var context = HttpContextFactory.Create("www.github.com", "?id=3", string.Empty, "GET");

            try
            {
                handler.ProcessRequest(context);
            }
            catch (Exception ex)
            {
                Assert.IsType<InvalidRequestTypeException>(ex);
            }
        }


        private static string GetTestJson(string jsonFile)
        {

            using (var stream = Assembly.GetAssembly(typeof(HookHttpHandlerTests)).GetManifestResourceStream(string.Format("HookService.Tests.{0}", jsonFile)))
            {
                if (stream == null)
                {
                    throw new ArgumentNullException("jsonFile");
                }
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
