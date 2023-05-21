
namespace Core.StateMachine
{
    public class PersistentStateNode : StateNode
    {
        public PersistentStateNode(IState state) : base(state)
        {
            
        }
    }
    
    public class PersistentStateNode<T> : StateNode<T>
    {
        public PersistentStateNode(IState<T> state) : base(state)
        {
            
        }
    }
    
    public class PersistentStateNode<T, D> : StateNode<T, D>
    {
        public PersistentStateNode(IState<T, D> state) : base(state)
        {
            
        }
    }
}

