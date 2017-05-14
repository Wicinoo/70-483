using System;

namespace Lessons._01
{
    public static class _08_Events
    {
        public static void Run()
        {
            var classWithAction = new ClassWithAction();
            classWithAction.OnAction += () => Console.WriteLine("Handler 1 of OnAction event.");
            classWithAction.OnAction += () => Console.WriteLine("Handler 2 of OnAction event.");

            classWithAction.Raise();

            var classWithEvent = new ClassWithEvent();
            classWithEvent.OnEvent += () => Console.WriteLine("Handler 1 of OnEvent event.");
            classWithEvent.OnEvent += () => Console.WriteLine("Handler 2 of OnEvent event.");

            classWithEvent.Raise();

            var classWithEventNullTest = new ClassWithEventRecomendSyntax();
            classWithEventNullTest.Raise();

        }
    }

    public class ClassWithAction
    {
        public Action OnAction { get; set; }

        public void Raise()
        {
            if (OnAction != null)
            {
                OnAction();
            }
        }
    }


    public class ClassWithEvent
    {
        public event Action OnEvent;

        public void Raise()
        {
            if (OnEvent != null)
            {
                OnEvent();  
            }
        }
    }
    public class ClassWithEventRecomendSyntax
    {
        public event Action OnEvent = delegate {}; //necessary!!!

        public void Raise()
        {
            OnEvent();  //because you used recomend syntax, you can avoid null check  
        }
    }
}