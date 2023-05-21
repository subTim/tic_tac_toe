namespace Infrastructure.GameState
{
    public interface IExitableState : IState
    {
        void Exit();
    }
}