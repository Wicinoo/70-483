using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._04
{
    public class CustomMissingFileException : Exception
    {
        public CustomMissingFileException(Exception e) : base("Missing file", e) { }
    }
}
