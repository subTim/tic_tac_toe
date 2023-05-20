using System;
using System.Collections.Generic;
using Infrastructure.GameState;
using Infrastructure.Services.Cells;

namespace Infrastructure.Services
{
    public class Winner
    {
        private readonly List<GameCell> _cells;
        private readonly GlobalStateMachine _machine;

        public Winner(List<GameCell> cells, GlobalStateMachine machine)
        {
            _cells = cells;
            _machine = machine;
        }

        public bool TryWin()
        {
            TryHorizontal();
            TryVertical();
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
            return IsEmpty(0) && _cells[0].Status == _cells[4].Status == _cells[8].Status;
        }
        
        private bool RightDiagonalFulled()
        {
            return IsEmpty(2) && _cells[2].Status == _cells[4].Status == _cells[6].Status;
        }

        private void TryVertical()
        {
            for (int i = 0; i < Constants.FIELD_SIDE_CAPACITY; i += 3)
            {
                if (IsEmpty(i) && _cells[i].Status == _cells[i + 1].Status == _cells[i + 2].Status)
                    Win();
            }
        }

        private bool IsEmpty(int item)
        {
            return _cells[item].Status == CellType.Empty;
        }

        private void TryHorizontal()
        {
            for (int i = 0; i < Constants.FIELD_SIDE_CAPACITY; i++)
            {
                if (IsEmpty(i) && _cells[i].Status == _cells[i + 3].Status == _cells[i + 6].Status)
                    Win();
            }
        }

        private void Win()
        {
            _machine.SetState<WinState>();
        }
    }
}