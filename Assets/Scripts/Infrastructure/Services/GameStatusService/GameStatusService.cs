using System;
using Data;
using GamePlay;
using GamePlay.Cells;
using UnityEngine;

namespace Infrastructure.Services
{
    public class GameStatusService : IDisposable, IService, IProgressReader, IProgressWriter
    {
        private readonly InputService _inputService;
        private readonly FieldChangesParser _changesParser;
        private GameStep _step;

        public GameStep Step => _step;

        public GameStatusService(InputService inputService, FieldChangesParser changesParser)
        {
            _inputService = inputService;
            _changesParser = changesParser;
            
            Subscribe();
        }

        public GameStep GetChangedStep()
        {
            return _step == GameStep.Circle ? GameStep.Cross : GameStep.Circle;
        }

        private void ChangeStep()
        {
            _step = GetChangedStep();
        }

        public void ResetStep()
        {
            _step = GameStep.Cross;
        }

        public void Read(Progress progress)
        {
            _step = (GameStep) progress.Step;
        }

        public void UpdateProgress(Progress progress)
        {
            
            progress.Step = (int)_step;
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
            
            _changesParser.Refresh();
        }
    }
}