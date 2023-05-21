using System.Collections.Generic;
using System.Linq;
using Data;
using DefaultNamespace;
using GamePlay;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly StaticData.StaticDataService _staticDataService;
        private readonly AssetsProvider _assetsProvider;

        public List<GameCell> Cells { get; set;}
        public List<IProgressWriter> ProgressWriters { get; set; } = new List<IProgressWriter>();
        public List<IProgressReader> ProgressReaders { get; set; } = new List<IProgressReader>();
        public WinScreen WinScreen { get; set; }
        public LooseScreen LooseScreen { get; set; }

        public GameFactory(ServiceLocator serviceLocator)
        {
            _staticDataService = serviceLocator.Single<StaticData.StaticDataService>();
            _assetsProvider = serviceLocator.Single<AssetsProvider>();
        }
        
        public GameObject CreateField()
        {
            var gameBoard = _assetsProvider.Instantiate(AssetsPath.GAME_BOARD);
            InitCells(gameBoard);
            return gameBoard;
        }

        public void CreateScreens()
        {
            LooseScreen = _assetsProvider.Instantiate(AssetsPath.LOOSE_SCREEN, false).GetComponent<LooseScreen>();
            WinScreen = _assetsProvider.Instantiate(AssetsPath.WIN_SCREEN, false).GetComponentInChildren<WinScreen>();
        }

        private void InitCells(GameObject gameBoard)
        {
            Cells = gameBoard.GetComponentsInChildren<GameCell>().ToList();

            foreach (var cell in Cells)
            {
                cell.Construct(_staticDataService.Storage);
                ProgressReaders.Add(cell);
                ProgressWriters.Add(cell);
            }
        }
    }
}