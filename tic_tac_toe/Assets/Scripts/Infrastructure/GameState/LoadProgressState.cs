using Data;
using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.GameState
{
    public class LoadProgressState : IEnterableState
    {
        private readonly SaveLoadService _saveLoadService;
        private readonly IGameFactory _gameFactory;
        private readonly GlobalStateMachine _stateMachine;

        public LoadProgressState(SaveLoadService saveLoadService, IGameFactory gameFactory, GlobalStateMachine stateMachine)
        {
            _saveLoadService = saveLoadService;
            _gameFactory = gameFactory;
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            LoadProgress();
            _stateMachine.SetState<PlayingState>();
        }

        private void LoadProgress()
        {
            Progress progress = _saveLoadService.LoadProgress();
            
            foreach (var reader in _gameFactory.ProgressReaders)
            {
                reader.Read(progress);
            }
        }
    }
}