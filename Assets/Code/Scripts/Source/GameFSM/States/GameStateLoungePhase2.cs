using Code.Scripts.Source.Managers;
using UnityEngine;

namespace Code.Scripts.Source.GameFSM.States
{
    public class GameStateLoungePhase2 : GameBaseState
    {
        private BookPuzzleManager _puzzleManager;
        
        public override void EnterState(GameStateManager context)
        {
          _puzzleManager = GameObject.FindObjectOfType<BookPuzzleManager>();
        }

        public override void UpdateState(GameStateManager context)
        {
            
            //action to check
            if (_puzzleManager.puzzleSolved)
            {
                context.SwitchState(context.GameStates.LaboratoryPhase1);
            }
        }

        public override void ExitState(GameStateManager context)
        {

        }
    }
}
