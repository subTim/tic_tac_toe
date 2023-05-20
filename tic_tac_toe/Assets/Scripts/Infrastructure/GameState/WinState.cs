using GamePlay;
using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.GameState
{
    public class WinState : IEnterableState, IExitableState
    {
        private readonly Restarter _restarter;
        private readonly IGameFactory _factory;
        private readonly GameStatusService _statusService;

        public WinState(Restarter restarter, IGameFactory factory, GameStatusService statusService)
        {
            _restarter = restarter;
            _factory = factory;
            _statusService = statusService;
        }
        
        public void Enter()
        {
            _factory.WinScreen.gameObject.SetActive(true);
            _factory.WinScreen.WinFrom.text = $"{_statusService.GetChangedStep()} Won!" ;
            _factory.WinScreen.RestartButton.onClick.AddListener( _restarter.Restart);
        }
        
        public void Exit()
        {
            _factory.WinScreen.gameObject.SetActive(false);
            _factory.WinScreen.RestartButton.onClick.RemoveAllListeners();
        }
    }
}