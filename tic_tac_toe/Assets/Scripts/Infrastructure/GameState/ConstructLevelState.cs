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
            _serviceLocator.Single<InputService>().Construct(
                _serviceLocator.Single<IGameFactory>().CreateField().GetComponent<GraphicRaycaster>());
        }
    }
}