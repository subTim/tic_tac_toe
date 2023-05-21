using Infrastructure;

namespace Ui
{
    public class Presenter : IPresenter
    {
        private readonly FinishWindow _presenting;

        public Presenter(FinishWindow presenting)
        {
            _presenting = presenting;
        }

        public void Show()
        {
            _presenting.Activate();
        }

        public void Hide()
        {
            _presenting.InActivate();
        }
    }
}