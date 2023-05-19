using Infrastructure.GameState;
using Infrastructure.Services.UpdateSystem;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour, IRoutineRunner
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
            Bootstrap();
        }

        private void Bootstrap()
        {
            Updater updater = gameObject.AddComponent<Updater>();
            Game game = new Game(this, updater);
            game.StateMachine.SetState<PlayingState>();
        }
    }
}
