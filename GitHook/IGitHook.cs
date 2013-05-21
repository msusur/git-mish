using GitHookController.Models;

namespace GitHookController
{
    public interface IGitHook
    {
        void GetHook(HookModel hookModel);
    }
}