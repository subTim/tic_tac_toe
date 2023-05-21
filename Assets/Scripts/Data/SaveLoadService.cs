using Infrastructure;
using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine;

namespace Data
{
    public class SaveLoadService : IService
    {
        private Progress _progress;
        
        public SaveLoadService(Progress progress)
        {
            _progress = progress;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(Constants.PROGRESS_KEY, _progress.ToJson());
        }

        public Progress LoadProgress()
        {
            var deserialized = PlayerPrefs.GetString(Constants.PROGRESS_KEY)?.ToDeserialized<Progress>();

            if (deserialized != null)
                _progress = deserialized;

            return _progress;
        }
    }
}