using System.ComponentModel.Design;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly StaticData.StaticData _staticData;
        private readonly AssetsProvider _assetsProvider;

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
            var cells = gameBoard.GetComponentsInChildren<GameCell>();

            foreach (var cell in cells)
            {
                cell.Construct(_staticData.Storage);
            }
        }
    }
}