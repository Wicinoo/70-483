using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
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

            // Bootstrap container and install all needed.
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            container.Register(Component.For<IEmotionHandler>().ImplementedBy<EmotionHandler>());
            container.Register(Component.For<IParticularEmotionHandler>().ImplementedBy<FearHandler>());
            container.Register(Component.For<IParticularEmotionHandler>().ImplementedBy<HungerHandler>());
            container.Register(Component.For<IParticularEmotionHandler>().ImplementedBy<AngerHandler>());

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
            private IEnumerable<IParticularEmotionHandler> _particularEmotionHandlers;

            public EmotionHandler(IEnumerable<IParticularEmotionHandler> particularEmotionHandlers)
            {
                _particularEmotionHandlers = particularEmotionHandlers;
            }

            public void Handle(EmotionType emotion)
            {
                _particularEmotionHandlers.ForEach(x => x.Handle(emotion));
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

                Console.WriteLine("Yo, mate, fear is the path to the dark side, so keep calm or draw your lightsaber !");
            }
        }

        public class HungerHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Hunger) return;

                Console.WriteLine("Yup, I can handler your hunger, go to Hungary!");
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
