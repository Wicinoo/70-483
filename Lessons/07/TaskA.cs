using System;
using System.Collections.Generic;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Linq;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;

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

            container.Install(new EmotionsInstaler());

            var emotionHandler = container.Resolve<IEmotionHandler
                >();

            emotionHandler.Handle(EmotionType.Anger);
            emotionHandler.Handle(EmotionType.Fear);
            emotionHandler.Handle(EmotionType.Hunger);
        }

        public class EmotionsInstaler : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

                container.Register(Component.For<IEmotionHandler>()
                                                .ImplementedBy<EmotionHandler>()
                                                .LifestyleTransient());

                container.Register(Component.For<IParticularEmotionHandler>()
                                                .ImplementedBy<AngerHandler>()
                                                .LifestyleTransient());

                container.Register(Component.For<IParticularEmotionHandler>()
                                                .ImplementedBy<HungerHandler>()
                                                .LifestyleTransient());

                container.Register(Component.For<IParticularEmotionHandler>()
                                                .ImplementedBy<FearHandler>()
                                                .LifestyleTransient());
            }
        }

        public interface IEmotionHandler
        {
            void Handle(EmotionType emotion);
        }

        public class EmotionHandler : IEmotionHandler
        {
            private readonly IEnumerable<IParticularEmotionHandler> _handlers;

            public EmotionHandler(IEnumerable<IParticularEmotionHandler> particularEmotionHandlers)
            {
                _handlers = particularEmotionHandlers;
            }

            public void Handle(EmotionType emotion)
            {
                IParticularEmotionHandler currentHandler = null;

                if(emotion == EmotionType.Fear)
                {
                    currentHandler = _handlers.Where(x => x.GetType() == typeof(FearHandler)).FirstOrDefault();
                }
                if (emotion == EmotionType.Hunger)
                {
                    currentHandler = _handlers.Where(x => x.GetType() == typeof(HungerHandler)).FirstOrDefault();
                }
                if (emotion == EmotionType.Anger)
                {
                    currentHandler = _handlers.Where(x => x.GetType() == typeof(AngerHandler)).FirstOrDefault();
                }

                if (currentHandler != null)
                {
                    currentHandler.Handle(emotion);
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

                Console.WriteLine("I'm so hungry, but so lazy to cook something.");
            }
        }

        public class FearHandler : IParticularEmotionHandler
        {
            public void Handle(EmotionType emotion)
            {
                if (emotion != EmotionType.Fear) return;

                Console.WriteLine("If you're afraid of wolves, don't go to forest.");
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
