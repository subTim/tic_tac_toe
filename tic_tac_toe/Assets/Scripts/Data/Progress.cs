using System;
using GamePlay.Cells;
using Infrastructure.Services;

namespace Data
{
    [Serializable]
    public class Progress : DictionaryFormatter<string, CellStatus>, IService
    {
        public GameStep Step;
    }
}