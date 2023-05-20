using UnityEngine;

namespace Infrastructure.GameState
{
    public class LooseState : IEnterableState
    {
        public void Enter()
        {
            Debug.Log("Loose");
        }
    }
}