using UnityEngine.Events;

namespace Core.StateMachine
{
    public class UnityStateTransitionEvent : IStateTransitionEvent
    {
        private UnityEvent unityEvent;

        public UnityStateTransitionEvent(UnityEvent unityEvent)
        {
            this.unityEvent = unityEvent;
        }
        
        public void AddListener(UnityAction transitionAction)
        {
            unityEvent.AddListener(transitionAction);
        }

        public void RemoveListener(UnityAction transitionAction)
        {
            unityEvent.RemoveListener(transitionAction);
        }
    }

    public static class UnityStateTransitionEvent_StateTransitionExtension
    {
        public static StateTransition OnEvent(this StateTransition stateTransition, UnityEvent unityEvent)
        {
            return stateTransition.OnEvent(new UnityStateTransitionEvent(unityEvent));
        }
    }
}
