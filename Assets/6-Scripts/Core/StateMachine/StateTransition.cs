using UnityEngine.Assertions;

namespace Core.StateMachine
{
    public class StateTransition
    {
        private StateMachine stateMachine;
        private IStateTransitionEvent transitionEvent;
        private StateNode targetState;
        public StateTransition(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public StateTransition OnEvent(IStateTransitionEvent transitionEvent)
        {
            Assert.IsNull(this.transitionEvent);
            this.transitionEvent = transitionEvent;
            return this;
        }
        
        public StateTransition From(StateNode state)
        {
            state.AddTransition(this);
            return this;
        }
        
        public StateTransition FromAny()
        {
            stateMachine.AddAnyStateTransition(this);
            return this;
        }

        public StateTransition To(StateNode targetState)
        {
            Assert.IsNull(this.targetState);
            this.targetState = targetState;
            return this;
        }

        public void Enable()
        {
            transitionEvent.AddListener(PerformTransition);
        }

        public void Disable()
        {
            transitionEvent.RemoveListener(PerformTransition);
        }

        private void PerformTransition()
        {
            stateMachine.TransitionToState(targetState);
        }
    }
}