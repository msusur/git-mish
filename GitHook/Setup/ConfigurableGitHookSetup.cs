using System;
using System.Collections.Generic;
using GitHookController.HookHandlers;
using GitHookController.Models;

namespace GitHookController.Setup
{
    public class ConfigurableGitHookSetup : IGitHookSetup
    {
        public string RepositoryName { get; set; }

        public string BranchName { get; set; }

        public IList<HandlerWrapper> Handlers { get; private set; }

        public ConfigurableGitHookSetup()
        {
            Handlers = new List<HandlerWrapper>();
        }

        public IGitHookSetup BranchOf(string branchName)
        {
            BranchName = branchName;
            return this;
        }

        public IGitHookSetup Then<THandlerType>()
            where THandlerType : IHandler
        {
            return Then(typeof(THandlerType));
        }

        public IGitHookSetup Then(Type handlerType)
        {
            if (!typeof(IHandler).IsAssignableFrom(handlerType))
            {
                throw new ArgumentException("Handlers must be derived from IHandler", "handlerType");
            }
            Handlers.Add(new HandlerWrapper(handlerType));
            return this;
        }

        public IGitHookSetup ThenRunInstance(IHandler instance)
        {
            Handlers.Add(new HandlerWrapper(instance));
            return this;
        }

        public void Save()
        {
            HookFactory.AddHookSetupForItem(this);
        }
    }
}