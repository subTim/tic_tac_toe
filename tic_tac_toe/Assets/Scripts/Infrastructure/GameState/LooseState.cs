using GamePlay;
using Infrastructure.Factory;

namespace Infrastructure.GameState
{
    public class LooseState : IEnterableState, IExitableState
    {
        private readonly Restarter _restarter;
        private readonly IGameFactory _gameFactory;

        public LooseState(Restarter restarter, IGameFactory gameFactory)
        {
            _restarter = restarter;
            _gameFactory = gameFactory;
        }
        
        public void Enter()
        {
            _gameFactory.LooseScreen.gameObject.SetActive(true);
            _gameFactory.LooseScreen.RestartButton.onClick.AddListener(_restarter.Restart);
        }

        public void Exit()
        {
            _gameFactory.LooseScreen.gameObject.SetActive(false);
            _gameFactory.LooseScreen.RestartButton.onClick.RemoveAllListeners();
        }
    }
}