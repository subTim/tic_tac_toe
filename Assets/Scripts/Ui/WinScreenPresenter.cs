using Infrastructure.Services;

namespace Ui
{
    public class WinScreenPresenter : IPresenter
    {
        private readonly IPresenter _presenter;
        private readonly GameStatusService _statusService;
        private readonly FinishWindow _window;

        public WinScreenPresenter(IPresenter presenter, GameStatusService statusService, FinishWindow window)
        {
            _presenter = presenter;
            _statusService = statusService;
            _window = window;
        }
        
        public void Show()
        {
            _window.Caption.text = $"{_statusService.GetChangedStep()} Won!";
            _presenter.Show();
        }

        public void Hide()
        {
            _presenter.Hide();
        }
    }
}