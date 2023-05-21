using System.Threading.Tasks;
using Core.Factory;
using Core.StateMachine;
using Game.Events;
using Game.GameLoop.States;
using UnityEngine;

namespace Game.GameLoop
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private SOEvent shutdownSignal;
        private StateMachine stateMachine;

        private void Start()
        {
            stateMachine = new StateMachine();
            
            ConstructGraph(stateMachine);
        }

        private void ConstructGraph(StateMachine stateMachine)
        {
            var graphConstructor = new StateMachineGraphConstructor(stateMachine);
            
            var bootingState = new FactoryStateNode<BootingState>(new BasicFactory<BootingState>());
            var menuState = new FactoryStateNode<MenuState>(new BasicFactory<MenuState>());
            var playingState = new FactoryStateNode<PlayingState>(new BasicFactory<PlayingState>());
            var cleanupState = new PersistentStateNode(new CleanupState());

            graphConstructor.InitialState(bootingState);
            
            graphConstructor.AddTransition().From(bootingState).To(menuState).OnEvent(GameEvents.BootingFinished);
            
            graphConstructor.AddTransition().From(menuState).To(playingState).OnEvent(GameEvents.PlayGame);
            
            graphConstructor.AddTransition().From(playingState).To(menuState).OnEvent(GameEvents.GoToMenu);
            
            graphConstructor.AddTransition().FromAny().To(cleanupState).OnEvent(shutdownSignal);
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
}
