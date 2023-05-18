using Game.Events;
using UnityEngine.Events;

namespace Core.StateMachine
{
    public class SOEventTransitionEvent : IStateTransitionEvent
    {
        private SOEvent SOEvent;
        public SOEventTransitionEvent(SOEvent SOEvent)
        {
            this.SOEvent = SOEvent;
        }

        public void AddListener(UnityAction transitionAction)
        {
            SOEvent.AddListener(transitionAction);
        }

        public void RemoveListener(UnityAction transitionAction)
        {
            SOEvent.RemoveListener(transitionAction);
        }
    }
    
    public static class SOEventTransitionEvent_StateTransitionExtension
    {
        public static StateTransition OnEvent(this StateTransition stateTransition, SOEvent SOEvent)
        {
            return stateTransition.OnEvent(new SOEventTransitionEvent(SOEvent));
        }
    }
}

