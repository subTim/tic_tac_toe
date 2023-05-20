using System;
using GamePlay;
using GamePlay.Cells;

namespace Infrastructure.Services
{
    public class GameStatusService : IDisposable, IService
    {
        private readonly InputService _inputService;
        private readonly FieldChangesParser _changesParser;
        private GameStep _step;

        public GameStatusService(InputService inputService, FieldChangesParser changesParser)
        {
            _inputService = inputService;
            _changesParser = changesParser;
            
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
                _changesParser.Refresh();
            }
        }

        private void ChangeStep()
        {
            _step = _step == GameStep.Circle ? GameStep.Cross : GameStep.Circle;
        }
    }
}