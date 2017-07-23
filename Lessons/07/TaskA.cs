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
    /// Install all needed components into the container. Use WindsorContainer.Register() method.
    /// Add support for resolving collections (CollectionResolver).
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IEmotionHandler>()
                .ImplementedBy<EmotionHandler>()
                .LifestylePerThread());

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Register(
                Component.For<IParticularEmotionHandler>().ImplementedBy<AngerHandler>(),
                Component.For<IParticularEmotionHandler>().ImplementedBy<FearHandler>());

            // Bootstrap container and install all needed.

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
            private readonly IEnumerable<IParticularEmotionHandler> _particularEmotionHandlers;

            public EmotionHandler(IEnumerable<IParticularEmotionHandler> particularEmotionHandlers)
            {
                _particularEmotionHandlers = particularEmotionHandlers;
            }

            public void Handle(EmotionType emotion)
            {
                foreach (var particularEmotionHandler in _particularEmotionHandlers)
                {
                    particularEmotionHandler.Handle(emotion);
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

                Console.WriteLine("Yep I am AngerHandler, I can handle your anger. Keep calm mate!");
            }
        }

        public class FearHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Fear) return;

                Console.WriteLine("Yep I am FearHandler, I can handle your fear. Keep calm mate!");
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
