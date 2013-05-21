using System;
using System.Collections.Generic;
using System.Linq;
using GitHookController.Exceptions;
using GitHookController.Models;
using GitHookController.Setup;

namespace GitHookController
{
    public class HookFactory
    {
        private static readonly IList<IGitHookSetup> HookSetups = new List<IGitHookSetup>();

        public static void AddHookSetupForItem(IGitHookSetup setup)
        {
            HookSetups.Add(setup);
        }

        public IGitHook GetHook(HookModel model)
        {
            var hookList = (from hooksetup in HookSetups
                     where
                         hooksetup.RepositoryName.Equals(model.repository.name,
                                                         StringComparison.InvariantCultureIgnoreCase)
                     select hooksetup).ToList();
            if (hookList.Count == 0)
            {
                throw new CannotFindAnySetupForGivenCurrentRepository(model.repository);
            }
            return new GitHook(hookList);
        }
    }
}