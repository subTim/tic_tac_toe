using Data;
using Infrastructure.Factory;

namespace Infrastructure.GameState
{
    public class SaveProgressState : IEnterableState
    {
        private readonly SaveLoadService _saveLoadService;
        private readonly IGameFactory _gameFactory;
        private readonly GlobalStateMachine _stateMachine;

        public SaveProgressState(SaveLoadService saveLoadService, IGameFactory gameFactory, GlobalStateMachine stateMachine)
        {
            _saveLoadService = saveLoadService;
            _gameFactory = gameFactory;
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            SaveProgress();
            _stateMachine.SetState<PlayingState>();
        }

        private void SaveProgress()
        {
            Progress progress = _saveLoadService.LoadProgress();
            WriteAll(progress);
            _saveLoadService.SaveProgress();
        }

        private void WriteAll(Progress progress)
        {
            foreach (var writer in _gameFactory.ProgressWriters)
            {
                writer.UpdateProgress(progress);
            }
        }
    }
}