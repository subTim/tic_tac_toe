using System.Collections.Generic;
using Data;
using DefaultNamespace;
using GamePlay;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateField();
        void CreateScreens();
        List<GameCell> Cells { get; set; }
        List<IProgressWriter> ProgressWriters { get; set; }
        List<IProgressReader> ProgressReaders { get; set; }
        WinScreen WinScreen { get; set; }
        LooseScreen LooseScreen { get; set; }
    }
}