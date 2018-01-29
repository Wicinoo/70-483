using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Anothers.Reflection
{
    public class GetAssemblies
    {
        public void Run()
        {

            List<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                  .Select(t => t.GetType())
                .Where(t => t.IsClass && t.Assembly == this.GetType().Assembly).ToList<Type>();
        }
    }
}
