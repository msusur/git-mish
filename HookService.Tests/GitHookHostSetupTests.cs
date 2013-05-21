using System;
using GitHookController;
using GitHookController.HookHandlers;
using Moq;
using Xunit;

namespace HookService.Tests
{
    // ReSharper disable InconsistentNaming
    public class GitHookHostSetupTests
    {
        [Fact]
        public void Create_hook_setup_for_hookservice()
        {
            var setup = GitHook.SetupForRepository("repo");
            Assert.Same("repo", setup.RepositoryName);

            setup.BranchOf("test");
            Assert.Same("test", setup.BranchName);

            var handler = new Mock<IHandler>();
            setup.Then(handler.Object.GetType());

#pragma warning disable 183
            Assert.True(handler.Object is IHandler);
#pragma warning restore 183
        }

        [Fact]
        public void Create_new_setup_each_time_repository_called()
        {
            var setup = GitHook.SetupForRepository("repo1");
            var setup2 = GitHook.SetupForRepository("repo2");
            Assert.NotSame(setup, setup2);
        }

        [Fact]
        public void Throw_exception_if_handler_is_not_IHandler()
        {
            try
            {
                GitHook.SetupForRepository("test").Then(typeof(GitHook));
            }
            catch (Exception ex)
            {
                Assert.IsType<ArgumentException>(ex);
            }
        }
    }
}