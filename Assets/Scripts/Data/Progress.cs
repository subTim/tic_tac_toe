using System;
using System.Collections.Generic;
using GamePlay.Cells;
using Infrastructure.Services;

namespace Data
{
    [Serializable]
    public class Progress :IService
    {
        public int Step;
        public DictionaryFormatter<string, CellStatus> CellsTable = new();
    }
}