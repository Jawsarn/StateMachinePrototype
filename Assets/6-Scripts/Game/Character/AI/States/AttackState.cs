using Core.Factory;
using Core.StateMachine;
using UnityEngine;

namespace Game.Character.AI
{
    public class AttackState : IState<GameObject>, IFactoryItemWithParams<AICharacterEvents, AICharacterData>
    {
        private AICharacterEvents AICharacterEvents;
        private AICharacterData AICharacterData;
        
        public void Initialize(AICharacterEvents AICharacterEvents, AICharacterData AICharacterData)
        {
            this.AICharacterEvents = AICharacterEvents;
            this.AICharacterData = AICharacterData;
        }

        public void Enter(GameObject gameObject)
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

