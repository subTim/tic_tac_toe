using Infrastructure.Factory;
using Infrastructure.GameState;
using Infrastructure.Services;
using Infrastructure.Services.UpdateSystem;

namespace Infrastructure
{
    public class Game
    {
        private readonly IRoutineRunner _routineRunner;
        private readonly Updater _updater;
        private StatesFactory _statesFactory;
        
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
            
            Locator.RegisterSingle(StateMachine);
            Locator.RegisterSingle(_updater);
            Locator.RegisterSingle(_routineRunner);
            
            _statesFactory = new StatesFactory(Locator);
            Locator.RegisterSingle<IStatesFactory>(_statesFactory);
            _statesFactory.CreateMainStates();
        }
    }
}