using System;
using GitHookController.HookHandlers;

namespace GitHookController.Models
{
    public class HandlerWrapper
    {
        public Type HandlerType { get; set; }
        public IHandler Instance { get; set; }

        public HandlerWrapper(Type handlerType)
        {
            if (handlerType == null)
            {
                throw new ArgumentNullException("handlerType");
            }
            HandlerType = handlerType;
        }

        public HandlerWrapper(IHandler instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            HandlerType = instance.GetType();
            Instance = instance;
        }

        public IHandler ActivateHandler()
        {
            return Instance ?? (Instance = Activator.CreateInstance(HandlerType) as IHandler);
        }
    }
}