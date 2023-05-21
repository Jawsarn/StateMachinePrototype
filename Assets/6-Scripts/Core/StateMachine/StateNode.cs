using System.Collections.Generic;
using UnityEngine;

namespace Core.StateMachine
{
    public interface IStateNode
    {
        public void Exit();
        public void AddTransition(IStateTransition stateTransition);
    }
    
    public abstract class StateNode : IStateNode
    {
        private List<IStateTransition> transitions = new List<IStateTransition>();
        protected IState state;

        protected StateNode(IState state)
        {
            this.state = state;
        }
        
        public void AddTransition(IStateTransition stateTransition)
        {
            transitions.Add(stateTransition);
        }
        
        public virtual void Enter()
        {
            Debug.Log("Entering state:" + state);
            EnableTransitions();
            state.Enter();
        }
        
        private void EnableTransitions()
        {
            foreach (var transition in transitions)
            {
                transition.Enable();
            }
        }
        
        public virtual void Exit()
        {
            DisableTransitions();
            state.Exit();
        }
        
        private void DisableTransitions()
        {
            foreach (var transition in transitions)
            {
                transition.Disable();
            }
        }
    }
    
    public abstract class StateNode<T> : IStateNode
    {
        private List<IStateTransition> transitions = new List<IStateTransition>();
        protected IState<T> state;

        protected StateNode(IState<T> state)
        {
            this.state = state;
        }
        
        public void AddTransition(IStateTransition stateTransition)
        {
            transitions.Add(stateTransition);
        }
        
        public virtual void Enter(T data)
        {
            Debug.Log("Entering state:" + state);
            EnableTransitions();
            state.Enter(data);
        }
        
        private void EnableTransitions()
        {
            foreach (var transition in transitions)
            {
                transition.Enable();
            }
        }
        
        public virtual void Exit()
        {
            DisableTransitions();
            state.Exit();
        }
        
        private void DisableTransitions()
        {
            foreach (var transition in transitions)
            {
                transition.Disable();
            }
        }
    }
    
    public abstract class StateNode<T, D> : IStateNode
    {
        private List<IStateTransition> transitions = new List<IStateTransition>();
        protected IState<T, D> state;

        protected StateNode(IState<T, D> state)
        {
            this.state = state;
        }
        
        public void AddTransition(IStateTransition stateTransition)
        {
            transitions.Add(stateTransition);
        }
        
        public virtual void Enter(T dataT, D dataD)
        {
            Debug.Log("Entering state:" + state);
            EnableTransitions();
            state.Enter(dataT, dataD);
        }
        
        private void EnableTransitions()
        {
            foreach (var transition in transitions)
            {
                transition.Enable();
            }
        }
        
        public virtual void Exit()
        {
            DisableTransitions();
            state.Exit();
        }
        
        private void DisableTransitions()
        {
            foreach (var transition in transitions)
            {
                transition.Disable();
            }
        }
    }
}
