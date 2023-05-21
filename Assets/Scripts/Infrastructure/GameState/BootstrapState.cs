using Data;
using GamePlay;
using Infrastructure.Factory;
using Infrastructure.Scenes;
using Infrastructure.Services;
using Infrastructure.Services.UpdateSystem;

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

        private void SetNext()
        {
            _machine.SetState<ConstructLevelState>();
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterSingle<StaticData.StaticDataService>(new StaticData.StaticDataService());
            
            _serviceLocator.RegisterSingle<AssetsProvider>(new AssetsProvider());
            _serviceLocator.RegisterSingle<Disposer>(new Disposer());

            _serviceLocator.RegisterSingle<IGameFactory>(new GameFactory(_serviceLocator));
            _serviceLocator.RegisterSingle<InputService>(new InputService());

            _updater.Register(_serviceLocator.Single<InputService>());
            _serviceLocator.RegisterSingle<SaveLoadService>(new SaveLoadService(new Progress()));

            _serviceLocator.RegisterSingle<Winner>(new Winner(_machine));
            _serviceLocator.RegisterSingle<Looser>(new Looser(_machine));
            _serviceLocator.RegisterSingle<FieldChangesParser>(new FieldChangesParser(_serviceLocator.Single<Winner>(), _serviceLocator.Single<Looser>()));
            _serviceLocator.RegisterSingle<GameStatusService>(new GameStatusService(_serviceLocator.Single<InputService>(), _serviceLocator.Single<FieldChangesParser>()));
            _serviceLocator.RegisterSingle<Restarter>(new Restarter(_machine, _serviceLocator.Single<IGameFactory>(), _serviceLocator.Single<GameStatusService>()));
            _serviceLocator.RegisterSingle<IUiFactory>(new UiFactory(_serviceLocator));

            _serviceLocator.Single<IStatesFactory>().CreateSubStates();
        }
    }
}