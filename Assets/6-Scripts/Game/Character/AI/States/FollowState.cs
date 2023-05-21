using Core.Factory;
using Core.StateMachine;
using UnityEngine;

namespace Game.Character.AI
{
    public class FollowState : IState<GameObject, float>, IFactoryItemWithParams<AICharacterEvents, AICharacterData>
    {
        private AICharacterEvents AICharacterEvents;
        private AICharacterData AICharacterData;

        public void Initialize(AICharacterEvents AICharacterEvents, AICharacterData AICharacterData)
        {
            this.AICharacterEvents = AICharacterEvents;
            this.AICharacterData = AICharacterData;
        }

        public void Enter(GameObject gameObject, float value)
        {
            
        }

        public void Exit()
        {
            
        }
    }
}