namespace Lessons._04
{
    public static class Runner
    {
        public static void Run()
        {
            _01_ManyCatchBranches.Run();
            //_02_MostImportantExceptionTypes.Run();
            //_03_RethrowingException.Run();
            //_04_ExceptionDispatchInfo.Run();

            //TaskA.Run();
            // TaskB contains xunit tests;
            TaskC.Run();
            TaskD.Run();

            //TaskE.Run1();
            TaskE.Run2();
        }
    }
}