using Data;
using Infrastructure.GameState;
using Infrastructure.Scenes;
using Infrastructure.Services;
using Infrastructure.Services.UpdateSystem;
using UnityEditorInternal;

namespace Infrastructure.Factory
{
    public class StatesFactory : IStatesFactory
    {
        private readonly ServiceLocator _locator;
        private readonly GlobalStateMachine _stateMachine;
        private readonly Updater _updater;
        private IRoutineRunner _routineRunner;

        public StatesFactory(ServiceLocator locator)
        {
            _locator = locator;
            
            _stateMachine = _locator.Single<GlobalStateMachine>();
            _updater = _locator.Single<Updater>();
            _routineRunner = _locator.Single<IRoutineRunner>();
        }

        public void CreateMainStates()
        {
            _stateMachine.AddState(new BootstrapState(_locator, _updater, _stateMachine, new SceneLoader(_routineRunner)));
            _stateMachine.AddState(new ConstructLevelState(_locator));
            _stateMachine.AddState(new PlayingState(_updater));
        }
        
        public void CreateSubStates()
        {
            CreateSeveLoadState();
            CreateLoadProgressState();
            
            _stateMachine.AddState(new WinState(_locator.Single<IUiFactory>()));
            _stateMachine.AddState(new LooseState(_locator.Single<IUiFactory>()));
        }

        private void CreateLoadProgressState()
        {
            _stateMachine.AddState<LoadProgressState>(new LoadProgressState(_locator.Single<SaveLoadService>(),
                _locator.Single<IGameFactory>(), _locator.Single<GlobalStateMachine>()));
        }

        private void CreateSeveLoadState()
        {
            _stateMachine.AddState<SaveProgressState>(new SaveProgressState(_locator.Single<SaveLoadService>(),
                _locator.Single<IGameFactory>(), _locator.Single<GlobalStateMachine>()));
        }
    }
}