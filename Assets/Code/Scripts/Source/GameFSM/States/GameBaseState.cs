using Code.Scripts.Source.Managers;

<<<<<<<< HEAD:Assets/Code/Scripts/Source/GameState/GameBaseState.cs
namespace Code.Scripts.Source.GameState
========
namespace Code.Scripts.Source.GameFSM.States
>>>>>>>> feature/game-management:Assets/Code/Scripts/Source/GameFSM/States/GameBaseState.cs
{
    public abstract class GameBaseState
    {
        public abstract void EnterState(GameStateManager context);

        public abstract void UpdateState(GameStateManager context);

        public abstract void ExitState(GameStateManager context);
    }
}
