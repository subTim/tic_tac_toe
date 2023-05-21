using System;
using Data;
using GamePlay;
using Infrastructure.Services;
using Ui;

namespace Infrastructure.Factory
{
    public class UiFactory : IUiFactory, IDisposable
    {
        public IPresenter LooseScreen { get; set; }
        public IPresenter WinScreen { get; set; }

        private FinishWindow _looseScreenView;
        private FinishWindow _winScreenView;

        private readonly AssetsProvider _assetsProvider;
        private readonly Disposer _disposer;
        private readonly Restarter _restarter;
        private readonly GameStatusService _statusService;


        public UiFactory(ServiceLocator locator)
        {
            _assetsProvider = locator.Single<AssetsProvider>();
            _disposer = locator.Single<Disposer>();
            _restarter = locator.Single<Restarter>();
            _statusService = locator.Single<GameStatusService>();
        }

        public void CreateScreens()
        {
            _looseScreenView = _assetsProvider.Instantiate(AssetsPath.LOOSE_SCREEN, false).GetComponent<FinishWindow>();
            _winScreenView = _assetsProvider.Instantiate(AssetsPath.WIN_SCREEN, false).GetComponentInChildren<FinishWindow>();
            Decorate();
            
            Subscribe();
        }

        private void Decorate()
        {
            LooseScreen = new Presenter(_looseScreenView);
            WinScreen = new WinScreenPresenter(new Presenter(_winScreenView), _statusService, _winScreenView);
        }

        private void Subscribe()
        {
            _looseScreenView.RestartButton.onClick.AddListener(_restarter.Restart);
            _winScreenView.RestartButton.onClick.AddListener(_restarter.Restart);
            _disposer.Add(this);
        }
        
        public void Dispose()
        {
            _looseScreenView.RestartButton.onClick.RemoveAllListeners();
            _winScreenView.RestartButton.onClick.RemoveAllListeners();
        }
    }
}