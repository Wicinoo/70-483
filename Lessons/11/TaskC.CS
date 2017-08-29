//C.Implement CredentialsVault in TaskC.cs.Use SHA256 hashing function and Base64 format to store hashed data.

//Possible output:

//Commands:
//N - new user
//L - login
//A - print all users
//Q - quit
//n

//Enter new user credentials...
//Username:
//adrian
//Password:
//123456
//User added

//Commands:
//N - new user
//L - login
//A - print all users
//Q - quit
//a

//All credentials:
//adrian,7CeKOJASh7J3GhNzlSA4TUPksHj3iv/nAt7xCHdMziQ=

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Lessons._11
{
    public class TaskC
    {
        private static CredentialsVault _credentialsVault = new CredentialsVault();

        private static IDictionary<ConsoleKey, Action> commands = new Dictionary<ConsoleKey, Action>()
        {
            {ConsoleKey.N, AddNewCredentials},
            {ConsoleKey.L, LoginUser},
            {ConsoleKey.A, PrintAllCredentials},
        };

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Commands:");
                Console.WriteLine("N - new user");
                Console.WriteLine("L - login");
                Console.WriteLine("A - print all users");
                Console.WriteLine("Q - quit");

                ConsoleKeyInfo keyInfo;

                do
                {
                    keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.Q) return;

                } while (!commands.ContainsKey(keyInfo.Key));

                Console.WriteLine();

                commands[keyInfo.Key].Invoke();

                Console.WriteLine();
            }
        }

        private static void PrintAllCredentials()
        {
            Console.WriteLine("All credentials:");

            var credentials = _credentialsVault.GetAllCredentials();

            foreach (var usernamePasswordPair in credentials)
            {
                Console.WriteLine($"{usernamePasswordPair.Key},{usernamePasswordPair.Value}");
            }
        }

        private static void AddNewCredentials()
        {
            Console.WriteLine("Enter new user credentials ...");

            Console.WriteLine("Username:");
            var username = Console.ReadLine();

            Console.WriteLine("Password:");
            var password = Console.ReadLine();

            _credentialsVault.AddCredentials(username, password);

            Console.WriteLine("User added");
        }

        private static void LoginUser()
        {
            Console.WriteLine("Login ...");

            Console.WriteLine("Username:");
            var username = Console.ReadLine();

            Console.WriteLine("Password:");
            var password = Console.ReadLine();

            var areValidCredentials = _credentialsVault.AreValidCredentials(username, password);

            Console.WriteLine($"Login result: {(areValidCredentials ? "Success" : "Failure")}");
        }

        /// <summary>
        /// Use SHA256 hashing function and Base64 format to store hashed data.
        /// </summary>
        public class CredentialsVault
        {
            private Dictionary<string, string> _database = new Dictionary<string, string>();
            private UnicodeEncoding _byteConverter = new UnicodeEncoding();
            private SHA256 _sha256 = SHA256.Create();

            public void AddCredentials(string username, string password)
            {
                var passwordHash = _sha256.ComputeHash(_byteConverter.GetBytes(password));
                _database.Add(username, Encoding.Default.GetString(passwordHash));
            }

            public bool AreValidCredentials(string username, string password)
            {
                if (_database.ContainsKey(username))
                {
                    var storedPassHash = _database[username];
                    var enteredPassHash = _sha256.ComputeHash(_byteConverter.GetBytes(password));

                    return storedPassHash.Equals(Encoding.Default.GetString(enteredPassHash));
                }
                return false;
            }

            public IReadOnlyDictionary<string, string> GetAllCredentials()
            {
                return _database;
            }
        }
    }
}
