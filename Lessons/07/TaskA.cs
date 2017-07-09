using System;
using System.Collections.Generic;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;

namespace Lessons._07
{
    /// <summary>
    /// Implement EmotionHandler.
    /// Implement IParticularEmotionHandler for Fear and Hunger.
    /// Bootstrap the container.
    /// Install all needed components into the container. Use WindsorContainer.Register() method.
    /// Add support for resolving collections (CollectionResolver).
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            using (var container = new WindsorContainer())
            {
                container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

                container.Register(Classes.FromThisAssembly().BasedOn<IParticularEmotionHandler>().WithService.Base());
                container.Register(Component.For<IEmotionHandler>().ImplementedBy<EmotionHandler>());
                // Bootstrap container and install all needed.

                var a = container.ResolveAll<IParticularEmotionHandler>();
                var emotionHandler = container.Resolve<IEmotionHandler>();

                emotionHandler.Handle(EmotionType.Anger);
                emotionHandler.Handle(EmotionType.Fear);
                emotionHandler.Handle(EmotionType.Hunger);
            }
        }

        public interface IEmotionHandler
        {
            void Handle(EmotionType emotion);
        }

        public class EmotionHandler : IEmotionHandler
        {
            private readonly IEnumerable<IParticularEmotionHandler> _particularEmotionHandlers;

            public EmotionHandler(IEnumerable<IParticularEmotionHandler> particularEmotionHandlers)
            {
                _particularEmotionHandlers = particularEmotionHandlers;
            }

            public void Handle(EmotionType emotion)
            {
                foreach (var handler in _particularEmotionHandlers)
                {
                    handler.Handle(emotion);
                }
            }
        }

        public interface IParticularEmotionHandler : IEmotionHandler
        {
        }

        public class AngerHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Anger) return;

                Console.WriteLine("Yep, I can handle your anger. Keep calm mate!");
            }
        }

        public class FearHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Fear) return;

                Console.WriteLine("Yep, I can handle your fear. Keep calm mate!");
            }
        }

        public class HungerHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Hunger) return;

                Console.WriteLine("Yep, I can handle your hunger. Keep calm mate!");
            }
        }

        public enum EmotionType
        {
            Anger,
            Fear,
            Hunger,
        }
    }
}
