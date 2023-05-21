using Data;
using GamePlay.Cells;
using Infrastructure.Services;
using Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class GameCell : MonoBehaviour, IProgressReader, IProgressWriter
    {
        [SerializeField] private Image _image;
        [SerializeField] private string _id;
        
        private CellStatus _status;
        private SpritesStorage _spriteStorage;
        public CellStatus Status => _status;
        

        public void Construct(SpritesStorage sprites)
        {
            _spriteStorage = sprites;
            UpdateViewStatus();
        }

        public void UpdateProgress(Progress progress)
        {
            progress.CellsTable[_id] = _status;
        }
        
        public void Read(Progress progress)
        {
            SetStatus(GetCellStatus(progress));
        }

        public void SetStatus(CellStatus status)
        {
            _status = status;
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

        private CellStatus GetCellStatus(Progress progress)
        {
            if (progress.CellsTable.Dictionary.ContainsKey(_id))
                return progress.CellsTable[_id];
            
            else
                return CellStatus.Empty;
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