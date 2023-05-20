using System.Collections.Generic;
using GamePlay;
using Infrastructure.Factory;
using Infrastructure.Scenes;
using Infrastructure.Services;
using Infrastructure.Services.UpdateSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.GameState
{
    public class BootstrapState : IEnterableState
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly Updater _updater;
        private readonly GlobalStateMachine _machine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(ServiceLocator serviceLocator, Updater updater, GlobalStateMachine machine, SceneLoader sceneLoader)
        {
            _serviceLocator = serviceLocator;
            _updater = updater;
            _machine = machine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(SceneNames.PLAYING_SCENE, SetNext);
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterSingle<Updater>(_updater);
            _serviceLocator.RegisterSingle<StaticData.StaticData>(new StaticData.StaticData());
            _serviceLocator.RegisterSingle<AssetsProvider>(new AssetsProvider());
            _serviceLocator.RegisterSingle<IGameFactory>(new GameFactory(_serviceLocator));
            _serviceLocator.RegisterSingle<InputService>(new InputService());
            ConfigureWinLooseSystem();
            _serviceLocator.RegisterSingle<GameStatusService>(new GameStatusService(_serviceLocator.Single<InputService>(), _serviceLocator.Single<FieldChangesParser>()));
            _serviceLocator.RegisterSingle(_machine);
            _updater.Register(_serviceLocator.Single<InputService>());
        }

        private void ConfigureWinLooseSystem()
        {
            List<GameCell> cells = _serviceLocator.Single<IGameFactory>().Cells;

            Winner winner = new Winner(cells, _machine);
            Looser looser = new Looser(cells, _machine);
            
            _serviceLocator.RegisterSingle<FieldChangesParser>(new FieldChangesParser(winner, looser));
        }

        private void SetNext()
        {
            _machine.SetState<ConstructLevelState>();
        }
    }
}