using System.Collections.Generic;
using System.Linq;
using GamePlay.Cells;
using Infrastructure.GameState;
using Infrastructure.Services;

namespace GamePlay
{
    public class Looser : IService
    {
        private readonly GlobalStateMachine _stateMachine;
        private List<GameCell> _cells;

        public Looser(GlobalStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Construct(List<GameCell> cells)
        {
            _cells = cells;
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