using System;
using System.Collections.Generic;
using System.Linq;
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

            // Bootstrap container and install all needed.
            container.Register(Component.For<IEmotionHandler>().ImplementedBy<EmotionHandler>());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Register(
                Component.For<IParticularEmotionHandler>().ImplementedBy<AngerHandler>(),
                Component.For<IParticularEmotionHandler>().ImplementedBy<FearHandler>(),
                Component.For<IParticularEmotionHandler>().ImplementedBy<HungerHandler>()
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
            private readonly IList<IParticularEmotionHandler> _particularEmotionHandlers; 

            public EmotionHandler(IEnumerable<IParticularEmotionHandler> particularEmotionHandlers)
            {
                _particularEmotionHandlers = particularEmotionHandlers.ToList();
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

                Console.WriteLine("Yep, I can handle your anger. Keep calm mate!");
            }
        }

        public class FearHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Fear) return;

                Console.WriteLine("Yep, I can handle my fears. Bring it on!");
            }
        }

        public class HungerHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Hunger) return;

                Console.WriteLine("Yep, I can handle my hunger. But I hope you don't take away my pizza.");
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
