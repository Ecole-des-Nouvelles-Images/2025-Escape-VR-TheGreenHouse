using Code.Scripts.Source.Managers;
using UnityEngine;

namespace Code.Scripts.Source.GameFSM.States
{
    public class GameStatePause : GameBaseState
    {
        public override void EnterState(GameStateManager context)
        {
            Time.timeScale = 0f;
            context.GamePaused = true;

            Debug.Log("Pause state entered!");
        }

        public override void UpdateState(GameStateManager context)
        {

        }

        public override void ExitState(GameStateManager context)
        {
            Time.timeScale = 1f;
            context.GamePaused = false;

            Debug.Log("Pause state exited!");
        }
    }
}
