using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.StaticData
{
    public class StaticData : IService
    {
        public SpritesStorage Storage;
        
        public StaticData()
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