using Core.Factory;
using Core.StateMachine;

namespace Game.Character.AI
{
    public class FollowState : IState, IFactoryItemWithParams<AICharacterEvents, AICharacterData>
    {
        private AICharacterEvents AICharacterEvents;
        private AICharacterData AICharacterData;

        public void Initialize(AICharacterEvents AICharacterEvents, AICharacterData AICharacterData)
        {
            this.AICharacterEvents = AICharacterEvents;
            this.AICharacterData = AICharacterData;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}