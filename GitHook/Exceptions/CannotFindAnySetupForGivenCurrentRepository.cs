using System;
using GitHookController.Models;

namespace GitHookController.Exceptions
{
    public class CannotFindAnySetupForGivenCurrentRepository : Exception
    {
        public CannotFindAnySetupForGivenCurrentRepository(HookModel.Repository repository)
            : base(string.Format("Can not find any setup for repository '{0}'", repository.name))
        {

        }
    }
}