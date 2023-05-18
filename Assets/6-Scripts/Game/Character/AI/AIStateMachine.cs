using System.Threading.Tasks;
using Core.Factory;
using Core.StateMachine;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Character.AI
{
    public class CharacterEvents
    {
        public UnityEvent death = new ();
    }
    
    public class AICharacterEvents
    {
        public UnityEvent foundEnemy = new ();
        public UnityEvent inRangeOfEnemy = new ();
        public UnityEvent lostTrackOfEnemy = new ();
    }

    public class AICharacterData
    {
        public GameObject activeTarget;
    }
    
    public class AIStateMachine : MonoBehaviour
    {
        private StateMachine stateMachine;
        public CharacterEvents characterEvents = new CharacterEvents();
        public AICharacterEvents AICharacterEvents = new AICharacterEvents();
        private AICharacterData AICharacterData = new AICharacterData();


        private void Start()
        {
            stateMachine = new StateMachine();
            ConstructGraph(stateMachine);
        }

        private void ConstructGraph(StateMachine stateMachine)
        {
            var graphConstructor = new StateMachineGraphConstructor(stateMachine);

            var idleState = new PersistentStateNode(new IdleState(AICharacterEvents, this));
            var followState = new FactoryStateNode<FollowState>(new BasicFactory<FollowState, AICharacterEvents, AICharacterData>(AICharacterEvents, AICharacterData));
            var attackState = new FactoryStateNode<AttackState>(new BasicFactory<AttackState, AICharacterEvents, AICharacterData>(AICharacterEvents, AICharacterData));
            var deathState = new PersistentStateNode(new DeathState());

            graphConstructor.InitialState(idleState);
            
            graphConstructor.AddTransition().From(idleState).To(followState).OnEvent(AICharacterEvents.foundEnemy);
            
            graphConstructor.AddTransition().From(followState).To(attackState).OnEvent(AICharacterEvents.inRangeOfEnemy);
            graphConstructor.AddTransition().From(followState).To(idleState).OnEvent(AICharacterEvents.lostTrackOfEnemy);
            
            graphConstructor.AddTransition().From(attackState).To(idleState).OnEvent(AICharacterEvents.lostTrackOfEnemy);
            
            graphConstructor.AddTransition().FromAny().To(deathState).OnEvent(characterEvents.death);
        }

        private async void OnEnable()
        {
            await Task.Yield();
            stateMachine?.StartStateMachine();
        }

        private void OnDisable()
        {
            stateMachine?.StopStateMachine();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AIStateMachine))]
    public class AIStateMachineEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            var behaviour = (AIStateMachine)target;
            if (GUILayout.Button("Invoke Death"))
            {
                behaviour.characterEvents.death.Invoke();
            }

            if (GUILayout.Button("Invoke foundEnemy"))
            {
                behaviour.AICharacterEvents.foundEnemy.Invoke();
            }
            
            if (GUILayout.Button("Invoke inRangeOfEnemy"))
            {
                behaviour.AICharacterEvents.inRangeOfEnemy.Invoke();
            }
            
            if (GUILayout.Button("Invoke lostTrackOfEnemy"))
            {
                behaviour.AICharacterEvents.lostTrackOfEnemy.Invoke();
            }
        }
    }
#endif
}

