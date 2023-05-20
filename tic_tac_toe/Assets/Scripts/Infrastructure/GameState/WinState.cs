using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.GameState
{
    public class WinState : IEnterableState
    {
        private readonly GameStatusService _statusService;

        public WinState(GameStatusService statusService)
        {
            _statusService = statusService;
        }
        
        public void Enter()
        {
            Debug.Log("Win");
        }
    }
}