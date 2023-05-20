using Data;
using GamePlay.Cells;
using Infrastructure.Factory;
using Infrastructure.GameState;
using Infrastructure.Services;

namespace GamePlay
{
    public class Restarter : IService
    {
        private readonly GlobalStateMachine _stateMachine;
        private readonly IGameFactory _factory;
        private readonly GameStatusService _statusService;

        public Restarter(GlobalStateMachine stateMachine, IGameFactory factory, GameStatusService statusService)
        {
            _stateMachine = stateMachine;
            _factory = factory;
            _statusService = statusService;
        }

        public void Restart()
        {
            ClearCells();
            _statusService.ResetStep();
            _stateMachine.SetState<PlayingState>();
        }

        private void ClearCells()
        {
            foreach (var cells in _factory.Cells)
            {
                cells.SetStatus(CellStatus.Empty);
            }
        }
    }
}