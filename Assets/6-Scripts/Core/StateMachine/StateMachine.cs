using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Core.StateMachine
{
    public class StateMachine
    {
        protected StateNode currentStateNode;
        protected StateNode initialStateNode;
        private List<StateTransition> anyStateTransitions = new List<StateTransition>();

        public void StartStateMachine()
        {
            Assert.IsNotNull(initialStateNode);
            
            EnableAnyStateTransitions();
            TransitionToState(initialStateNode);
        }

        private void EnableAnyStateTransitions()
        {
            foreach (var transition in anyStateTransitions)
            {
                transition.Enable();
            }
        }

        public void StopStateMachine()
        {
            DisableAnyStateTransitions();
            TransitionToState(null);
        }
        
        private void DisableAnyStateTransitions()
        {
            foreach (var transition in anyStateTransitions)
            {
                transition.Disable();
            }
        }

        public void TransitionToState(StateNode newState)
        {
            currentStateNode?.Exit();
            currentStateNode = newState;
            currentStateNode?.Enter();
        }
        
        public void SetInitialState(StateNode initialState)
        {
            this.initialStateNode = initialState;
        }

        public void AddAnyStateTransition(StateTransition newTransition)
        {
            anyStateTransitions.Add(newTransition);
        }
    }
}
