using System.Collections.Generic;
using GamePlay;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.Windows.WebCam;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateField();
        List<GameCell> Cells { get; set; }
    }
}