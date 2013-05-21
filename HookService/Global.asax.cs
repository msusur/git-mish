using System;
using System.Web;
using System.Web.Routing;
using GitHookController;

namespace HookService
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GitHook.SetupForRepository("testing").BranchOf("master").Then<StandardBuildOperation>().Save();

            RouteTable.Routes.Add(new Route("Github/ci", new HookHttpHandler(new HookFactory())));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}