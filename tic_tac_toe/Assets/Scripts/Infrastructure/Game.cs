using Infrastructure.GameState;
using Infrastructure.Scenes;
using Infrastructure.Services;
using Infrastructure.Services.UpdateSystem;

namespace Infrastructure
{
    public class Game
    {
        private readonly IRoutineRunner _routineRunner;
        private readonly Updater _updater;
        public GlobalStateMachine StateMachine;
        public ServiceLocator Locator;
        
        public Game(IRoutineRunner routineRunner, Updater updater)
        {
            _routineRunner = routineRunner;
            _updater = updater;
            ConstructStateMachine();
        }

        private void ConstructStateMachine()
        {
            Locator = ServiceLocator.Container;
            
            StateMachine = new GlobalStateMachine();
            StateMachine.AddState(new BootstrapState(ServiceLocator.Container, _updater, StateMachine, new SceneLoader(_routineRunner)));
            StateMachine.AddState(new ConstructLevelState(ServiceLocator.Container));
            StateMachine.AddState(new PlayingState(_updater));
        }
    }
}