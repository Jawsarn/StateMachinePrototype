
namespace Core.StateMachine
{
    public class StateMachineGraphConstructor
    {
        private StateMachine stateMachine;
        public StateMachineGraphConstructor(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        public void InitialState(StateNode initState)
        {
            stateMachine.SetInitialState(initState);
        }

        public StateTransition AddTransition()
        {
            return new StateTransition(stateMachine);
        }
    }
}

