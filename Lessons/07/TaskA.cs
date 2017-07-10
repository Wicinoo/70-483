using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace Lessons._07
{
    /// <summary>
    /// Implement EmotionHandler.
    /// Implement IParticularEmotionHandler for Fear and Hunger.
    /// Bootstrap the container.
    /// Register all needed components into the container. Use WindsorContainer.Register() method.
    /// Add support for resolving collections (CollectionResolver).
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            var container = new WindsorContainer();

            Bootstrapper.Register(container);

            var emotionHandler = container.Resolve<IEmotionHandler>();

            emotionHandler.Handle(EmotionType.Anger);
            emotionHandler.Handle(EmotionType.Fear);
            emotionHandler.Handle(EmotionType.Hunger);
        }

        public interface IEmotionHandler
        {
            void Handle(EmotionType emotion);
        }

        public class EmotionHandler : IEmotionHandler
        {
            public EmotionHandler(IEnumerable<IParticularEmotionHandler> particularEmotionHandlers)
            {
                foreach (var particularEmotionHandler in particularEmotionHandlers)
                {
                    particularEmotionHandler.Handle(EmotionType.Anger);
                    particularEmotionHandler.Handle(EmotionType.Fear);
                    particularEmotionHandler.Handle(EmotionType.Hunger);
                }
            }

            public void Handle(EmotionType emotion)
            {
                Console.WriteLine("Hi, I am your {0}", emotion);
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

                Console.WriteLine("Yep, I can handle your fear. Fear Not!");
            }
        }

        public class HungerHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Hunger) return;

                Console.WriteLine("Yep, I can handle your Hunger. Eat Up!");
            }
        }

        public enum EmotionType
        {
            Anger,
            Fear,
            Hunger,
        }
    }

    public static class Bootstrapper
    {
        public static void Register(WindsorContainer container)
        {
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Register(Component.For<TaskA.IEmotionHandler>().ImplementedBy<TaskA.EmotionHandler>());
            container.Register(Component.For<TaskA.IParticularEmotionHandler>().ImplementedBy<TaskA.AngerHandler>());
            container.Register(Component.For<TaskA.IParticularEmotionHandler>().ImplementedBy<TaskA.FearHandler>());
            container.Register(Component.For<TaskA.IParticularEmotionHandler>().ImplementedBy<TaskA.HungerHandler>());
        }
    }
}
