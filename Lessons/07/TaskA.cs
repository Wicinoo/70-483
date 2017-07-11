using System;
using System.Collections.Generic;

using Castle.Windsor;

namespace Lessons._07
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;

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
            var container = new WindsorContainer();

            // Bootstrap container and install all needed.
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Register(Component.For<IEmotionHandler>().ImplementedBy<EmotionHandler>());
            container.Register(
                Classes.FromThisAssembly().BasedOn<IParticularEmotionHandler>().WithServiceBase()
                    .AllowMultipleMatches());

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
            private readonly IEnumerable<IParticularEmotionHandler> particularEmotionHandlers;

            public EmotionHandler(IEnumerable<IParticularEmotionHandler> particularEmotionHandlers)
            {
                this.particularEmotionHandlers = particularEmotionHandlers;
            }

            public void Handle(EmotionType emotion)
            {
                foreach (var handler in particularEmotionHandlers)
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

                Console.WriteLine("Yep, I can handle your fear. Be brave!");
            }
        }

        public class HungerHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Hunger) return;

                Console.WriteLine("Yep, I can handle your hunger. Take the cake!");
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