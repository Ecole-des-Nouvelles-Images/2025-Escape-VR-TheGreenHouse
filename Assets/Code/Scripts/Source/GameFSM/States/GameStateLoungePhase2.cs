using System;
using Code.Scripts.Source.Gameplay.Lounge;
using Code.Scripts.Source.Managers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Scripts.Source.GameFSM.States
{
    public class GameStateLoungePhase2 : GameBaseState
    {
        public static Action OnSocketChanged;
        public static Action<bool> OnFusePlugged;
        private BookPuzzle _puzzle;
        
        public override void EnterState(GameStateManager context)
        { 
            _puzzle = Object.FindFirstObjectByType<BookPuzzle>();
        }

        public override void UpdateState(GameStateManager context)
        {
            //action to check
            if (_puzzle.PuzzleSolved)
            {
                context.SwitchState(context.GameStates.LaboratoryPhase1);
                Debug.Log(context.GameStates.LaboratoryPhase1);
            }
        }

        public override void ExitState(GameStateManager context)
        {
            
        }
    }
}
