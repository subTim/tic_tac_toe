using System.Collections.Generic;
using System.Linq;
using GamePlay;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly StaticData.StaticData _staticData;
        private readonly AssetsProvider _assetsProvider;

        public List<GameCell> Cells { get; set;}

        public GameFactory(ServiceLocator serviceLocator)
        {
            _staticData = serviceLocator.Single<StaticData.StaticData>();
            _assetsProvider = serviceLocator.Single<AssetsProvider>();
        }
        
        public GameObject CreateField()
        {
            var gameBoard = _assetsProvider.Instantiate(AssetsPath.GAME_BOARD);
            InitCells(gameBoard);
            return gameBoard;
        }

        private void InitCells(GameObject gameBoard)
        {
            Cells = gameBoard.GetComponentsInChildren<GameCell>().ToList();

            foreach (var cell in Cells)
            {
                cell.Construct(_staticData.Storage);
            }
        }
    }
}