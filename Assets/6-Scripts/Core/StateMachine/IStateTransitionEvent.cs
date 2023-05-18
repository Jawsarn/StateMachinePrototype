using UnityEngine.Events;

namespace Core.StateMachine
{
    public interface IStateTransitionEvent
    {
        void AddListener(UnityAction transitionAction);
        void RemoveListener(UnityAction transitionAction);
    }
}
