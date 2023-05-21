using Infrastructure.Services.UpdateSystem;

namespace Infrastructure.GameState
{
    public class PlayingState : IEnterableState, IExitableState
    {
        private readonly Updater _updater;

        public PlayingState(Updater updater)
        {
            _updater = updater;
        }
        public void Enter()
        {
            _updater.IsEnableToUpdate = true;
        }

        public void Exit()
        {
            _updater.IsEnableToUpdate = false;
        }
    }
}