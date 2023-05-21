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
    
    public class UnityStateTransitionEvent<T> : IStateTransitionEvent<T>
    {
        private UnityEvent<T> unityEvent;

        public UnityStateTransitionEvent(UnityEvent<T> unityEvent)
        {
            this.unityEvent = unityEvent;
        }
        
        public void AddListener(UnityAction<T> transitionAction)
        {
            unityEvent.AddListener(transitionAction);
        }

        public void RemoveListener(UnityAction<T> transitionAction)
        {
            unityEvent.RemoveListener(transitionAction);
        }
    }
    
    public class UnityStateTransitionEvent<T, D> : IStateTransitionEvent<T, D>
    {
        private UnityEvent<T, D> unityEvent;

        public UnityStateTransitionEvent(UnityEvent<T, D> unityEvent)
        {
            this.unityEvent = unityEvent;
        }
        
        public void AddListener(UnityAction<T, D> transitionAction)
        {
            unityEvent.AddListener(transitionAction);
        }

        public void RemoveListener(UnityAction<T, D> transitionAction)
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
        
        public static StateTransition<T> OnEvent<T>(this StateTransition<T> stateTransition, UnityEvent<T> unityEvent)
        {
            return stateTransition.OnEvent(new UnityStateTransitionEvent<T>(unityEvent));
        }
        
        public static StateTransition<T, D> OnEvent<T, D>(this StateTransition<T, D> stateTransition, UnityEvent<T, D> unityEvent)
        {
            return stateTransition.OnEvent(new UnityStateTransitionEvent<T, D>(unityEvent));
        }
    }
}
