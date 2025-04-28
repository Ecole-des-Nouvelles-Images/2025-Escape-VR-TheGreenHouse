using Code.Scripts.Source.Managers;

namespace Code.Scripts.Source.GameStates
{
    public abstract class GameBaseState
    {
        public abstract void EnterState(GameStateManager context);

        public abstract void UpdateState(GameStateManager context);

        public abstract void ExitState(GameStateManager context);
    }
}
