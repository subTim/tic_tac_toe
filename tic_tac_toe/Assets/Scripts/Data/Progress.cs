using System;
using System.Collections.Generic;
using GamePlay.Cells;
using Infrastructure.Services;

namespace Data
{
    [Serializable]
    public class Progress : DictionaryFormatter<string, CellStatus>, IService
    {
        public int Step;
        public Dictionary<string, CellStatus> CellsTable => Dictionary;
    }
}