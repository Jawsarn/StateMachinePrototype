
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
        
        public StateTransition<T> AddTransition<T>()
        {
            return new StateTransition<T>(stateMachine);
        }
        
        public StateTransition<T, D> AddTransition<T, D>()
        {
            return new StateTransition<T, D>(stateMachine);
        }
    }
}

