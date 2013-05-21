using System.Collections.Generic;
using System.Linq;
using GitHookController.Models;
using GitHookController.Setup;

namespace GitHookController
{
    public class GitHook : IGitHook
    {
        public IList<IGitHookSetup> GitHookSetups { get; private set; }

        public GitHook(IEnumerable<IGitHookSetup> gitHookSetups)
        {
            GitHookSetups = new List<IGitHookSetup>(gitHookSetups);
        }

        public static IGitHookSetup SetupForRepository(string repositoryName)
        {
            return new ConfigurableGitHookSetup() { RepositoryName = repositoryName };
        }

        public void GetHook(HookModel hookModel)
        {
            foreach (var handler in from gitHookSetup in GitHookSetups from handlerWrapper in gitHookSetup.Handlers select handlerWrapper.ActivateHandler())
            {
                handler.HandleHook(hookModel);
            }
        }
    }
}