//Task E: Read JSON from http://api.icndb.com/jokes/random and print the text of a joke. 
//Use a helper(e.g.JObject from Newtonsoft.Json) for converting to an object. 

using System;
using System.Collections.Generic;

namespace Lessons._14
{
    static class TaskE
    {
        public class JsonJoke
        {
            public string Type { get; set; }

            public JokeValue Value { get; set; }
        }

        internal class JokeValue
        {
            private string Id { get; set; }

            public string Joke { get; set; }

            public List<string> Categories { get; set; }
        }

        public static void Run()
        {
            string address = "http://api.icndb.com/jokes/random";
            var json = DownloadJson(address);
            ProcessJsonString(json);
            //TODO implement
        }

        private static void ProcessJsonString(string json)
        {
            var joke = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonJoke>(json);
            Console.WriteLine($"{joke.Value.Joke}");
        }

        private static string DownloadJson(string address)
        {
            using (var webClinet = new System.Net.WebClient())
            {
                var json = webClinet.DownloadString(address);
                return json;
            }
        }
    }

    
}
