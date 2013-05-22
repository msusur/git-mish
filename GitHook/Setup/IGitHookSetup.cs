using System;
using System.Collections.Generic;
using System.Web.Routing;
using GitHookController.HookHandlers;
using GitHookController.Models;

namespace GitHookController.Setup
{
    public interface IGitHookSetup
    {
        string RepositoryName { get; set; }
        string BranchName { get; set; }
        IList<HandlerWrapper> Handlers { get; }

        IGitHookSetup BranchOf(string branchName);
        IGitHookSetup Then<THandlerType>() where THandlerType : IHandler;
        IGitHookSetup Then(Type handlerType);
        IGitHookSetup ThenRunInstance(IHandler instance);

        void Save();
        void Save(RouteCollection routes, string route);
    }
}