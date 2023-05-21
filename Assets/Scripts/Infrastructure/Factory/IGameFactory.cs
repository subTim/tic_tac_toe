using System.Collections.Generic;
using Data;
using GamePlay;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateField();
        List<GameCell> Cells { get; set; }
        List<IProgressWriter> ProgressWriters { get; set; }
        List<IProgressReader> ProgressReaders { get; set; }
    }
}