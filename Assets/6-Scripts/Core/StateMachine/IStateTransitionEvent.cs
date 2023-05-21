using UnityEngine.Events;

namespace Core.StateMachine
{
    public interface IStateTransitionEvent
    {
        void AddListener(UnityAction transitionAction);
        void RemoveListener(UnityAction transitionAction);
    }
    
    public interface IStateTransitionEvent<T>
    {
        void AddListener(UnityAction<T> transitionAction);
        void RemoveListener(UnityAction<T> transitionAction);
    }
    
    public interface IStateTransitionEvent<T, D>
    {
        void AddListener(UnityAction<T, D> transitionAction);
        void RemoveListener(UnityAction<T, D> transitionAction);
    }
}
