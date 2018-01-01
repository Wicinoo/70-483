//Task E: Read JSON from http://api.icndb.com/jokes/random and print the text of a joke. 
//Use a helper(e.g.JObject from Newtonsoft.Json) for converting to an object. 

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Lessons._14
{
    static class TaskE
    {
        public class JsonJoke
        {
            public string Type { get; set; }

            public JokeValue Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        internal class JokeValue
        {
            private string Id { get; set; }

            public string Joke { get; set; }

            public List<string> Categories { get; set; }

            public override string ToString()
            {
                return Joke;
            }
        }

        public static void Run()
        {
            using (WebClient client = new WebClient())
            {
                string data = client.DownloadString("http://api.icndb.com/jokes/random");
                var joke = JsonConvert.DeserializeObject<JsonJoke>(data);
                Console.WriteLine(joke);
            }
        }
    }

    
}
