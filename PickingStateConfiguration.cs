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
                 .OnEntry(x => test());
            return t;
        }

        public static void test()
        {
            Console.WriteLine("OnEntry");
        }
    }

    public static class SortingStateConfiguration
    {
        public static Stateless.StateMachine<State, Trigger>.StateConfiguration SortingAddConfiguration(this StateMachine<State, Trigger> pickingConfiguration, bool isSingle)
        {
            var t = pickingConfiguration.Configure(State.Sorting)
                .Permit(Trigger.Move, State.Packing)
                 .OnEntry(x => test());
            return t;
        }

        public static void test()
        {
            Console.WriteLine("OnEntry");
        }
    }
}