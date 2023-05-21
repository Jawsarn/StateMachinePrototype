
namespace Core.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
    
    public interface IState<T>
    {
        void Enter(T data);
        void Exit();
    }
    
    public interface IState<T, D>
    {
        void Enter(T dataT, D dataD);
        void Exit();
    }
}