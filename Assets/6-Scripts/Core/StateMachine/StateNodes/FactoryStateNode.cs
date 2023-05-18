using Core.Factory;

namespace Core.StateMachine
{
    public class FactoryStateNode<T> : StateNode where T : IState, new()
    {
        private IFactory<T> stateFactory;
        
        public FactoryStateNode(IFactory<T> stateFactory) : base(null)
        {
            this.stateFactory = stateFactory;
        }

        public override void Enter()
        {
            state = stateFactory.Create();
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            state = null;
        }
    }
}
