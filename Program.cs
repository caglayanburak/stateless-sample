using System;

namespace StateMachineSample
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskState state = new TaskState(false, State.Picking);
            state.ChangeTo(Trigger.Move);

            Console.WriteLine(state.State);
            Console.ReadLine();
        }
    }
}
