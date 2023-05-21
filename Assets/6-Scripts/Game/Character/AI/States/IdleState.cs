using System;
using System.Collections;
using Core.StateMachine;
using UnityEngine;

namespace Game.Character.AI
{
    public class IdleState : IState
    {
        private AICharacterEvents AICharacterEvents;
        private MonoBehaviour coroutineProvider;
        private Coroutine routine;
        
        public IdleState(AICharacterEvents AICharacterEvents, MonoBehaviour coroutineProvider)
        {
            this.AICharacterEvents = AICharacterEvents;
            this.coroutineProvider = coroutineProvider;
        }

        public void Enter()
        {
            routine = coroutineProvider.StartCoroutine(IdleRoutine());
        }

        public void Exit()
        {
            coroutineProvider.StopCoroutine(routine);
        }
        
        private IEnumerator IdleRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                AICharacterEvents.foundEnemy.Invoke(null, 1.0f);
            }
        }
    }
}