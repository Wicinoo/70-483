using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public class Runner
    {
        
        public static void Run()
        {
            new TaskA();
            new B();

            TaskC.Run();
            TaskD.Run();
            TaskE.Run();
            TaskF.Run();
            TaskG.Run();
        }
    }
}
