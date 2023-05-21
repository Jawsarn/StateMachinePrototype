
namespace Core.StateMachine
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface IState : IExitableState
    {
        void Enter();
    }
    
    public interface IState<T> : IExitableState
    {
        void Enter(T data);
    }
    
    public interface IState<T, D> : IExitableState
    {
        void Enter(T dataT, D dataD);
    }
}