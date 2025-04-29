using Code.Scripts.Source.Managers;

namespace Code.Scripts.Source.GameFSM.States
{
    public class GameStatePause : GameBaseState
    {
        public override void EnterState(GameStateManager context)
        {
            context.GamePaused = true;

            
        }

        public override void UpdateState(GameStateManager context)
        {

        }

        public override void ExitState(GameStateManager context)
        {

        }
    }
}
