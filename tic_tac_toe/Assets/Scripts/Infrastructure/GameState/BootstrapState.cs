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
            _sceneLoader.Load(SceneNames.PLAYING_SCENE);
            _machine.SetState<PlayingState>();
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterSingle<InputService>(new InputService());
            _serviceLocator.RegisterSingle<Updater>(_updater);
            _updater.Register(_serviceLocator.Single<InputService>());
        }
    }
}