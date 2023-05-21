using System;
using Infrastructure.GameState;
using Infrastructure.Services;
using Infrastructure.Services.UpdateSystem;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour, IRoutineRunner
    {
        private Game _game;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            Bootstrap();
        }

        private void Bootstrap()
        {
            Updater updater = gameObject.AddComponent<Updater>();
            _game = new Game(this, updater);
            _game.StateMachine.SetState<BootstrapState>();
        }

        private void OnDestroy()
        {
            _game.Locator.Single<Disposer>().DisposeAll();
        }
    }
}
