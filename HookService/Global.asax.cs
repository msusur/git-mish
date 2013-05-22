using System;
using System.Web;
using System.Web.Routing;
using GitHookController;
using HookService;

namespace HookServiceSandbox
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GitHook.SetupForRepository("testing").BranchOf("master")
                .Then<StandardBuildOperation>()
                .Save(RouteTable.Routes, "Github/ci");
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