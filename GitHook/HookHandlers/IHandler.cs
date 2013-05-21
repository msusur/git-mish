using GitHookController.Models;

namespace GitHookController.HookHandlers
{
    public interface IHandler
    {
        void HandleHook(HookModel hookModel);
    }
}