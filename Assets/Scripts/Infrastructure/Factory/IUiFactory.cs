using Infrastructure.Services;
using Ui;

namespace Infrastructure.Factory
{
    public interface IUiFactory : IService
    {
        IPresenter LooseScreen { get; set; }
        IPresenter WinScreen { get; set; }

        void CreateScreens();
    }
}