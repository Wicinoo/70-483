using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

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

            // Register components
            container.Register(Component.For<IUsernamesProvider>().ImplementedBy<UsernameProvider>());
            container.Register(Component.For<ExpiringCachedContentBase>().ImplementedBy<ExpiringCachedContent>().LifestyleSingleton());
            container.Register(Component.For<IDateTimeNowProvider>().ImplementedBy<DateTimeNowProvider>());
            container.Register(Component.For<IUsernamesRepository>().ImplementedBy<UsernamesRepository>());

            Action getAllUserNames = () =>
            {
                Console.WriteLine("Asking for all usernames ...");
                var usernameProvider = container.Resolve<IUsernamesProvider>();
                usernameProvider.GetAllUsernames();
            };

            Task.Run(() =>
            {
                Thread.Sleep(2 * CacheMaxAgeInMilliseconds);
                getAllUserNames();
            });

            Task.Run(() =>
            {
                getAllUserNames();
            });

            getAllUserNames();
        }
        
        public interface IUsernamesProvider
        {
            IEnumerable<string> GetAllUsernames();
        }

        public class UsernameProvider : IUsernamesProvider
        {
            private readonly ExpiringCachedContentBase _expiringCachedContent;

            public UsernameProvider(ExpiringCachedContentBase expiringCachedContent)
            {
                _expiringCachedContent = expiringCachedContent;
            }

            public IEnumerable<string> GetAllUsernames()
            {
                return _expiringCachedContent.GetAllUsernames();
            }
        }

        public class ExpiringCachedContent : ExpiringCachedContentBase
        {
            private readonly IUsernamesRepository _usernamesRepository;
            private IEnumerable<string> _cachedUsernames;

            public ExpiringCachedContent(IDateTimeNowProvider dateTimeNowProvider, IUsernamesRepository usernamesRepository) 
                : base(dateTimeNowProvider, CacheMaxAgeInMilliseconds)
            {
                _usernamesRepository = usernamesRepository;
            }

            protected override void RefreshCachedContent()
            {
                _cachedUsernames = _usernamesRepository.GetAllUsernames();
            }

            public override IEnumerable<string> GetAllUsernames()
            {
                return Get(() => _cachedUsernames);
            }
        }

        public interface IDateTimeNowProvider
        {
            DateTime Now { get; }
        }

        public class DateTimeNowProvider : IDateTimeNowProvider
        {
            public DateTime Now
            {
                get
                {
                    return DateTime.Now;
                }
            }
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

            public abstract IEnumerable<string> GetAllUsernames();
        }
    }
}