//Task E: Read JSON from http://api.icndb.com/jokes/random and print the text of a joke. 
//Use a helper(e.g.JObject from Newtonsoft.Json) for converting to an object. 

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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
            //TODO implement
        }
    }

    
}
