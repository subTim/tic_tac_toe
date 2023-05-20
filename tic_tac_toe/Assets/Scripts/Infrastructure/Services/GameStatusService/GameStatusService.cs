using System;
using Infrastructure.Services.Cells;

namespace Infrastructure.Services
{
    public class GameStatusService : IDisposable, IService
    {
        private readonly InputService _inputService;
        private GameStep _step;

        public GameStatusService(InputService inputService)
        {
            _inputService = inputService;
            Subscribe();
        }

        private void Subscribe()
        {
            _inputService.OnCellTap += MakeStep;
        }

        public void Dispose()
        {
            _inputService.OnCellTap -= MakeStep;
        }

        private void MakeStep(GameCell cell)
        {
            if (cell.Status == CellStatus.Empty)
            {
                cell.OnTap(_step);
                ChangeStep();
            }
        }

        private void ChangeStep()
        {
            _step = _step == GameStep.Circle ? GameStep.Cross : GameStep.Circle;
        }
    }
}