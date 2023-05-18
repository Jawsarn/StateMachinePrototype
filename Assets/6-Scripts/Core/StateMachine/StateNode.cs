using System.Collections.Generic;
using UnityEngine;

namespace Core.StateMachine
{
    public abstract class StateNode
    {
        private List<StateTransition> transitions = new List<StateTransition>();
        protected IState state;

        protected StateNode(IState state)
        {
            this.state = state;
        }
        
        public void AddTransition(StateTransition stateTransition)
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
}
