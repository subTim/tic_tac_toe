using GamePlay;
using Infrastructure.Factory;

namespace Infrastructure.GameState
{
    public class LooseState : IEnterableState, IExitableState
    {
        private readonly IUiFactory _uiFactory;

        public LooseState(IUiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void Enter()
        {
            _uiFactory.LooseScreen.Show();
        }

        public void Exit()
        {
            _uiFactory.LooseScreen.Hide();
        }
    }
}