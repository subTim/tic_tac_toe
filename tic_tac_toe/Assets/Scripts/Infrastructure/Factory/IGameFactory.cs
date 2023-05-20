using System.Collections.Generic;
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
        WinScreen WinScreen { get; set; }
        LooseScreen LooseScreen { get; set; }
    }
}