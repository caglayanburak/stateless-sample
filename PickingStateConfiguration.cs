using System;
using Stateless;

namespace StateMachineSample
{
    public static class PickingStateConfiguration
    {
        public static Stateless.StateMachine<State, Trigger>.StateConfiguration PickingAddConfiguration(this StateMachine<State, Trigger> pickingConfiguration, bool isSingle)
        {
            var t = pickingConfiguration.Configure(State.Picking)
                 .PermitIf(Trigger.Move, State.Sorting, () => !isSingle)
                 .PermitIf(Trigger.Move, State.Packing, () => isSingle)
                 .OnExit(x =>new CustomAction().InvokeExit("exit 1"))
                 .OnEntry(x => new CustomAction().InvokeEntry("message 1"));

            return t;
        }
    }

    public static class SortingStateConfiguration
    {
        public static Stateless.StateMachine<State, Trigger>.StateConfiguration SortingAddConfiguration(this StateMachine<State, Trigger> pickingConfiguration, bool isSingle)
        {
            var t = pickingConfiguration.Configure(State.Sorting)
                .Permit(Trigger.Move, State.Packing)
                .OnExit(x =>new CustomAction().InvokeExit("exit 2"))
                 .OnEntry(x => new CustomAction().InvokeEntry("message 2"));


            return t;
        }

        public static void test()
        {
            Console.WriteLine("OnEntry");
        }
    }
}