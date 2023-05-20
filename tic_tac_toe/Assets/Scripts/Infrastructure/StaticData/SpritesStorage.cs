using System.Collections.Generic;
using GamePlay.Cells;
using UnityEngine;

namespace Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "SpritesStorage", menuName = "StaticData/Sprites")]
    public class SpritesStorage : ScriptableObject
    {
       [SerializeField] private Sprite _cross;
       [SerializeField] private Sprite _circle;

       public Dictionary<CellStatus, Sprite> Sprites;

       public void Init()
       {
           Sprites = new Dictionary<CellStatus, Sprite>()
           {
               { CellStatus.Circle, _circle },
               { CellStatus.Cross, _cross },
           };
       }
    }
}