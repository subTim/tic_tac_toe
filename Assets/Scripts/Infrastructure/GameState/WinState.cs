using GamePlay;
using Infrastructure.Factory;
using Infrastructure.Services;

namespace Infrastructure.GameState
{
    public class WinState : IEnterableState, IExitableState
    {
        private readonly IUiFactory _uiFactory;

        public WinState(IUiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void Enter()
        {
            _uiFactory.WinScreen.Show();
        }
        
        public void Exit()
        {
            _uiFactory.WinScreen.Hide();
        }
    }
}