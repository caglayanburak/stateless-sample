using Microsoft.Extensions.DependencyInjection;
using System;

namespace StateMachineSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                       .AddSingleton<ICustomAction, CustomAction>()
                       .BuildServiceProvider();

            var action = serviceProvider.GetService<ICustomAction>();

            TaskState state = new TaskState(false, action, State.Picking);
            state.ChangeTo(Trigger.Move);

            Console.WriteLine(state.State);
            Console.ReadLine();
        }
    }
}
