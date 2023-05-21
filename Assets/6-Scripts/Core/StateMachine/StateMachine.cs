using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Core.StateMachine
{
    public class StateMachine
    {
        protected IExitableStateNode currentStateNode;
        protected StateNode initialStateNode;
        private List<IStateTransition> anyStateTransitions = new List<IStateTransition>();

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
            newState?.Enter();
        }
        
        public void TransitionToState<T>(StateNode<T> newState, T data)
        {
            currentStateNode?.Exit();
            currentStateNode = newState;
            newState?.Enter(data);
        }

        public void SetInitialState(StateNode initialState)
        {
            this.initialStateNode = initialState;
        }

        public void AddAnyStateTransition(IStateTransition newTransition)
        {
            anyStateTransitions.Add(newTransition);
        }
    }
}
