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
    
    public class FactoryStateNode<T, D> : StateNode<D> where T : IState<D>, new()
    {
        private IFactory<T> stateFactory;
        
        public FactoryStateNode(IFactory<T> stateFactory) : base(null)
        {
            this.stateFactory = stateFactory;
        }

        public override void Enter(D d)
        {
            state = stateFactory.Create();
            base.Enter(d);
        }

        public override void Exit()
        {
            base.Exit();
            state = null;
        }
    }
    
    public class FactoryStateNode<T, D, E> : StateNode<D, E> where T : IState<D, E>, new()
    {
        private IFactory<T> stateFactory;
        
        public FactoryStateNode(IFactory<T> stateFactory) : base(null)
        {
            this.stateFactory = stateFactory;
        }

        public override void Enter(D d, E e)
        {
            state = stateFactory.Create();
            base.Enter(d, e);
        }

        public override void Exit()
        {
            base.Exit();
            state = null;
        }
    }
}
