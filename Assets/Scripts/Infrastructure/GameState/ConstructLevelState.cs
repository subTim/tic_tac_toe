using System.Collections.Generic;
using GamePlay;
using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine;
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
            _serviceLocator.Single<GlobalStateMachine>().SetState<LoadProgressState>();
        }

        private void Construct()
        {
            IGameFactory gameFactory = _serviceLocator.Single<IGameFactory>();
            
            GameObject gameField = gameFactory.CreateField();
            _serviceLocator.Single<IUiFactory>().CreateScreens();
            _serviceLocator.Single<InputService>().Construct(gameField.GetComponent<GraphicRaycaster>());
            gameField.GetComponentInChildren<Button>().onClick.AddListener(() => _serviceLocator.Single<GlobalStateMachine>().SetState<SaveProgressState>());
            
            gameFactory.ProgressReaders.Add(_serviceLocator.Single<GameStatusService>());
            gameFactory.ProgressWriters.Add(_serviceLocator.Single<GameStatusService>());
            
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