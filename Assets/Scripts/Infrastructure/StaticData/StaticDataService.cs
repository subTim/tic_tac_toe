using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.StaticData
{
    public class StaticDataService : IService
    {
        public SpritesStorage Storage;
        
        public StaticDataService()
        {
            LoadSprites();
        }

        private void LoadSprites()
        {
            Storage = Resources.Load<SpritesStorage>(AssetsPath.SPRITE_STORAGE);
            Storage.Init();
        }
    }
}