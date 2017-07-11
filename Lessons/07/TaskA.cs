using System;
using System.Collections.Generic;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

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

            // Bootstrap container and install all needed.
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Register(
                Component.For<IEmotionHandler>().ImplementedBy<EmotionHandler>(),
                Component.For<IParticularEmotionHandler>().ImplementedBy<AngerHandler>(),
                Component.For<IParticularEmotionHandler>().ImplementedBy<HungerHandler>(),
                Component.For<IParticularEmotionHandler>().ImplementedBy<FearHandler>()
            );

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
            private IEnumerable<IParticularEmotionHandler> _handlers;

            public EmotionHandler(IEnumerable<IParticularEmotionHandler> handlers)
            {
                _handlers = handlers;
            }

            public void Handle(EmotionType emotion)
            {
                foreach (var handler in _handlers)
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

        public class HungerHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Hunger) return;

                Console.WriteLine("Yep, I can handle your hunger. Keep calm mate!");
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

        public enum EmotionType
        {
            Anger,
            Fear,
            Hunger,
        }
    }
}
