using System.Collections.Generic;
using System.Linq;
using GamePlay.Cells;
using Infrastructure.GameState;

namespace GamePlay
{
    public class Looser
    {
        private readonly List<GameCell> _cells;
        private readonly GlobalStateMachine _stateMachine;

        public Looser(List<GameCell> cells, GlobalStateMachine stateMachine)
        {
            _cells = cells;
            _stateMachine = stateMachine;
        }

        public void TryLoose()
        {
            if (_cells.All(cell => cell.Status != CellStatus.Empty))
                Loose();
        }

        private void Loose()
        {
            _stateMachine.SetState<LooseState>();
        }
    }
}