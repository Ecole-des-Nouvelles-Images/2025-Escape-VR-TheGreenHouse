using Code.Scripts.Source.Managers;
using UnityEngine;

namespace Code.Scripts.Source.GameFSM.States
{
    public class GameStateMainMenu : GameBaseState
    {
        public override void EnterState(GameStateManager context)
        {
            Debug.Log("[GameStateMainMenu] MainMenu successfully loaded.");
        }

        public override void UpdateState(GameStateManager context)
        {
        }

        public override void ExitState(GameStateManager context)
        {
        }
    }
}
