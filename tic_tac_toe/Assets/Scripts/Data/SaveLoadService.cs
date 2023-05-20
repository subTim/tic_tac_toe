using Infrastructure;
using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine;

namespace Data
{
    public class SaveLoadService : IService
    {
        private readonly Progress _progress;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(Progress progress, IGameFactory gameFactory)
        {
            _progress = progress;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (IProgressWriter progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progress);
      
            PlayerPrefs.SetString(Constants.PROGRESS_KEY, _progress.ToJson());
        }

        public Progress LoadProgress()
        {
            return PlayerPrefs.GetString(Constants.PROGRESS_KEY)?.ToDeserialized<Progress>();
        }
    }
}