using UnityEngine.Assertions;

namespace Core.StateMachine
{
    public interface IStateTransition
    {
        public void Enable();
        public void Disable();
    }
    
    public class StateTransition : IStateTransition
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
        
        public StateTransition From<T>(StateNode<T> state)
        {
            state.AddTransition(this);
            return this;
        }
        
        public StateTransition From<T ,D>(StateNode<T, D> state)
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
    
    public class StateTransition<T> : IStateTransition
    {
        private StateMachine stateMachine;
        private IStateTransitionEvent<T> transitionEvent;
        private StateNode<T> targetState;
        
        public StateTransition(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public StateTransition<T> OnEvent(IStateTransitionEvent<T> transitionEvent)
        {
            Assert.IsNull(this.transitionEvent);
            this.transitionEvent = transitionEvent;
            return this;
        }
        public StateTransition<T> From(StateNode state)
        {
            state.AddTransition(this);
            return this;
        }
        
        public StateTransition<T> From<E>(StateNode<E> state)
        {
            state.AddTransition(this);
            return this;
        }
        
        public StateTransition<T> From<E, F>(StateNode<E, F> state)
        {
            state.AddTransition(this);
            return this;
        }

        public StateTransition<T> FromAny()
        {
            stateMachine.AddAnyStateTransition(this);
            return this;
        }

        public StateTransition<T> To(StateNode<T> targetState)
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

        private void PerformTransition(T data)
        {
            stateMachine.TransitionToState(targetState, data);
        }
    }
    
    public class StateTransition<T, D> : IStateTransition
    {
        private StateMachine stateMachine;
        private IStateTransitionEvent<T, D> transitionEvent;
        private StateNode<T, D> targetState;
        
        public StateTransition(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public StateTransition<T, D> OnEvent(IStateTransitionEvent<T, D> transitionEvent)
        {
            Assert.IsNull(this.transitionEvent);
            this.transitionEvent = transitionEvent;
            return this;
        }
        public StateTransition<T, D> From(StateNode state)
        {
            state.AddTransition(this);
            return this;
        }
        
        public StateTransition<T, D> From(StateNode<T> state)
        {
            state.AddTransition(this);
            return this;
        }

        public StateTransition<T, D> FromAny()
        {
            stateMachine.AddAnyStateTransition(this);
            return this;
        }

        public StateTransition<T, D> To(StateNode<T, D> targetState)
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

        private void PerformTransition(T dataT, D dataD)
        {
            stateMachine.TransitionToState(targetState, dataT, dataD);
        }
    }
}