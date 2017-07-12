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
            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            /*var particularEmotionHandlers = new List<IParticularEmotionHandler>();
            particularEmotionHandlers.Add(new FearHandler());
            particularEmotionHandlers.Add(new AngerHandler());
            particularEmotionHandlers.Add(new HungerHandler());*/

            // Bootstrap container and install all needed.
            //var registration = Component.For<IEmotionHandler>().Instance(new EmotionHandler(particularEmotionHandlers));
            //container.Register(registration);

            container.Register(
                Component.For<IEmotionHandler>().ImplementedBy<EmotionHandler>(),

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
            private List<IParticularEmotionHandler> _particularEmotionHandlers;

            public EmotionHandler(IEnumerable<IParticularEmotionHandler> particularEmotionHandlers)
            {
                _particularEmotionHandlers = new List<IParticularEmotionHandler>(particularEmotionHandlers);
            }

            public void Handle(EmotionType emotion)
            {
                foreach (var emotionHandler in _particularEmotionHandlers)
                {
                    emotionHandler.Handle(emotion);
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

                Console.WriteLine("Fear Handler");
            }
        }

        public class HungerHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Hunger) return;

                Console.WriteLine("Hunger Handler");
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
