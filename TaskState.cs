using Stateless;

namespace StateMachineSample
{
    public enum Trigger
    {
        //        Picked,
        //        Sorted,
        //        Packed,
        //        Loaded
        Move
    };
    public enum State
    {
        Picking = 4,
        Sorting = 8,
        Packing = 9,
        Loading = 6
    };
    public class TaskState
    {
        private readonly StateMachine<State, Trigger> _stateMachine;
        public TaskState(bool isSingle, State initialState = default(State))
        {
            _stateMachine = new StateMachine<State, Trigger>(initialState);
            _stateMachine.PickingAddConfiguration(isSingle);
            _stateMachine.SortingAddConfiguration(isSingle);
            _stateMachine.Configure(State.Packing)
                .Permit(Trigger.Move, State.Loading);
            _stateMachine.Configure(State.Loading)
                .Ignore(Trigger.Move);
        }
        public State State => _stateMachine.State;
        // For state changes that do not require parameters.
        public void ChangeTo(Trigger trigger)
        {
            _stateMachine.Fire(trigger);
        }
    }
}