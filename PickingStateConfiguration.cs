using Stateless;
using System;

namespace StateMachineSample
{
    public static class MainStateConfiguration<T>
    {


    }


    public static class PickingStateConfiguration
    {
        public static Stateless.StateMachine<State, Trigger>.StateConfiguration PickingAddConfiguration(this StateMachine<State, Trigger> pickingConfiguration, bool isSingle, ICustomAction action)
        {
            var customAction = new CustomAction();
            Console.WriteLine(DateTime.Now);
            var t = pickingConfiguration.Configure(State.Picking)
                 .PermitIf(Trigger.Move, State.Sorting, () => !isSingle)
                 .PermitIf(Trigger.Move, State.Packing, () => isSingle)
                 .OnExit(x => action.OnExit("exit 1"))
                 .OnEntry(x => action.OnEntry("message 1"));
            return t;
        }
    }

    public static class SortingStateConfiguration
    {
        public static Stateless.StateMachine<State, Trigger>.StateConfiguration SortingAddConfiguration(this StateMachine<State, Trigger> pickingConfiguration, bool isSingle, ICustomAction action)
        {
            var t = pickingConfiguration.Configure(State.Sorting)
                .Permit(Trigger.Move, State.Packing)
                .OnExit(x => action.OnExit("exit 2"))
                 .OnEntry(x => action.OnEntry("message 2"));
            return t;
        }
        
    }

}