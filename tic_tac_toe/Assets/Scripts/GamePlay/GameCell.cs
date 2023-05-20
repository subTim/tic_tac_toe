using Infrastructure.Services.Cells;
using Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Services
{
    public class GameCell : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        private CellStatus _status;
        private SpritesStorage _spriteStorage;
        public CellStatus Status => _status;

        public void Construct(SpritesStorage sprites)
        {
            _spriteStorage = sprites;
            UpdateViewStatus();
        }

        public void OnTap(GameStep status)
        {
            switch (status)
            {
                case GameStep.Circle:
                    _status = CellStatus.Circle;
                    break;
                case GameStep.Cross:
                    _status = CellStatus.Cross;
                    break;
            }
            
            UpdateViewStatus();
        }

        private void UpdateViewStatus()
        {
            if(_status != CellStatus.Empty)
                SetSprite(_spriteStorage.Sprites[_status]);
            else
                SetAlfa(0);
        }

        private void SetSprite(Sprite sprite)
        {
            SetAlfa(1);
            _image.sprite = sprite;
        }

        private void SetAlfa(float value)
        {
            _image.color = new Color(256, 256, 256, value);
        }
    }
}