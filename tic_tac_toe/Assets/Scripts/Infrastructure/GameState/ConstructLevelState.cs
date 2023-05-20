using System.Collections.Generic;
using GamePlay;
using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine.UI;

namespace Infrastructure.GameState
{
    public class ConstructLevelState : IEnterableState
    {
        private readonly ServiceLocator _serviceLocator;

        public ConstructLevelState(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Enter()
        {
            Construct();
            _serviceLocator.Single<GlobalStateMachine>().SetState<PlayingState>();
        }

        private void Construct()
        {
            IGameFactory gameFactory = _serviceLocator.Single<IGameFactory>(); 
            _serviceLocator.Single<InputService>().Construct(gameFactory.CreateField().GetComponent<GraphicRaycaster>());
            gameFactory.CreateScreens();
            
            ConfigureWinLooseSystem();
        }
        
        private void ConfigureWinLooseSystem()
        {
            List<GameCell> cells = _serviceLocator.Single<IGameFactory>().Cells;

            _serviceLocator.Single<Winner>().Construct(cells);            
            _serviceLocator.Single<Looser>().Construct(cells);
        }
    }
}