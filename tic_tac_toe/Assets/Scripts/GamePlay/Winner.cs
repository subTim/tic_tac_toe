using System.Collections.Generic;
using GamePlay.Cells;
using Infrastructure;
using Infrastructure.GameState;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay
{
    public class Winner : IService
    {
        private readonly GlobalStateMachine _machine;
        private List<GameCell> _cells;
 
        public Winner(GlobalStateMachine machine)
        {
            _machine = machine;
        }

        public void Construct(List<GameCell> cells)
        {
            _cells = cells;
        }

        public bool TryWin()
        {
            TryVertical();
            TryHorizontal();
            TryCross();

            return _machine.CompareState<WinState>();
        }

        private void TryCross()
        {
            if(RightDiagonalFulled() || LeftDiagonalFulled())
                Win();
        }

        private bool LeftDiagonalFulled()
        {
            return IsNotEmpty(0) && IsValidCells(0, 4);
        }
        
        private bool RightDiagonalFulled()
        {
            return IsNotEmpty(2) && IsValidCells(2, 2);;
        }

        private void TryHorizontal()
        {
            for (int i = 0, j = 0; i < Constants.FIELD_SIDE_CAPACITY; i ++, j += 3)
            {
                if (IsNotEmpty(j) && IsValidCells(j, 1))
                    Win();
            }
        }

        private bool IsNotEmpty(int item)
        {
            return _cells[item].Status != CellStatus.Empty;
        }

        private void TryVertical()
        {
            for (int i = 0; i < Constants.FIELD_SIDE_CAPACITY; i++)
            {
                if (IsNotEmpty(i) && IsValidCells(i, 3))
                    Win();
            }
        }

        private bool IsValidCells(int startIndex, int increaseStep)
        {
            var startCell = _cells[startIndex].Status;
            
            return startCell == _cells[startIndex + increaseStep].Status &&
                   startCell == _cells[startIndex + increaseStep * 2].Status;
        }
        private void Win()
        {
            _machine.SetState<WinState>();
        }
    }
}