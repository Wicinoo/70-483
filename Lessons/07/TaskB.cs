using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Lessons._07
{
    /// <summary>
    /// Register components in the container.
    /// There are some intentional errors in binding abstractions and implementations.
    /// Fix them to make the cache working.
    /// In case of the proper implementation, message "Getting usernames from database ..."
    /// should be printed out two times.
    /// </summary>
    public class TaskB
    {
        private const int CacheMaxAgeInMilliseconds = 1000;

        public static void Run()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IUsernamesProvider>().ImplementedBy<UsernamesProvider>().LifeStyle.Singleton);
            container.Register(Component.For<IUsernamesRepository>().ImplementedBy<UsernamesRepository>().LifeStyle.Singleton);
            container.Register(Component.For<IDateTimeNowProvider>().ImplementedBy<DateTimeNowProvider>().DependsOn(Dependency.OnValue<DateTime>(DateTime.Now)).LifeStyle.Singleton);

            // Register components

            Action getAllUserNames = () =>
            {
                Console.WriteLine("Asking for all usernames ...");
                var usernameProvider = container.Resolve<IUsernamesProvider>();
                var usernames = usernameProvider.GetAllUsernames();
                foreach (var username in usernames)
                {
                    Console.WriteLine(username);
                }
            };

            Task.Run(() =>
            {
                Thread.Sleep(2 * CacheMaxAgeInMilliseconds);
                getAllUserNames();
            });

            Task.Run(() =>
            {
                Console.WriteLine();
                getAllUserNames();
            });

            getAllUserNames();
        }
        
        public interface IUsernamesProvider : IUsernamesRepository
        {
        }

        public class UsernamesProvider : ExpiringCachedContentBase, IUsernamesProvider
        {
            private readonly IUsernamesRepository _usernamesRepository;
            private IEnumerable<string> _cachedUsernames;

            public UsernamesProvider(IDateTimeNowProvider dateTimeNowProvider, IUsernamesRepository usernamesRepository) 
                : base(dateTimeNowProvider, CacheMaxAgeInMilliseconds)
            {
                _usernamesRepository = usernamesRepository;
            }

            protected override void RefreshCachedContent()
            {
                _cachedUsernames = _usernamesRepository.GetAllUsernames();
            }

            public IEnumerable<string> GetAllUsernames()
            {
                return Get(() => _cachedUsernames);
            }
        }

        public class DateTimeNowProvider : IDateTimeNowProvider
        {
            public DateTime Now { get; private set; }
            
            public DateTimeNowProvider(DateTime dateTime)
            {
                Now = dateTime;
            }
        }

        public interface IDateTimeNowProvider
        {
            DateTime Now { get; }
        }

        public interface IUsernamesRepository
        {
            IEnumerable<string> GetAllUsernames();
        }

        private class UsernamesRepository : IUsernamesRepository
        {
            public IEnumerable<string> GetAllUsernames()
            {
                Console.WriteLine("Getting usernames from database ...");
                Thread.Sleep(100);
                return new[] { "user1", "admin23", "anonymous" };
            }
        }

        /// <summary>
        /// Provides thread-safe support for cached content with expiration.
        /// Use protected generic Get method internally to ensure validity of content.
        /// It's expected that descendants of the base class are set as singletons and could be accessed by many threads in parallel.
        /// </summary>
        public abstract class ExpiringCachedContentBase
        {
            private readonly IDateTimeNowProvider _dateTimeNowProvider;
            private readonly int _maxAgeInMilliseconds;
            private DateTime _contentValidityExpirationDate = DateTime.MinValue;
            private readonly object _lock = new object();

            protected ExpiringCachedContentBase(IDateTimeNowProvider dateTimeNowProvider, int maxAgeInMilliseconds)
            {
                _dateTimeNowProvider = dateTimeNowProvider;
                _maxAgeInMilliseconds = maxAgeInMilliseconds;
            }

            protected abstract void RefreshCachedContent();

            protected T Get<T>(Func<T> func)
            {
                lock (_lock)
                {
                    CheckContentValidity();
                    return func();
                }
            }

            protected void CheckContentValidity()
            {
                if (_contentValidityExpirationDate >= _dateTimeNowProvider.Now) return;

                RefreshCachedContent();
                _contentValidityExpirationDate = _dateTimeNowProvider.Now.AddMilliseconds(_maxAgeInMilliseconds);
            }
        }
    }
}