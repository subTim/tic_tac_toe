namespace Infrastructure.GameState
{
    public interface IEnterableState : IState
    {
        void Enter();
    }
}