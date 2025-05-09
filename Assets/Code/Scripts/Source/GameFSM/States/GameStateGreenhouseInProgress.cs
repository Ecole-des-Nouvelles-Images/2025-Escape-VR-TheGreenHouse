using Code.Scripts.Source.Managers;
using UnityEngine;using System;
using Code.Scripts.Source.Gameplay.Lounge;
using Code.Scripts.Source.Managers;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Code.Scripts.Source.GameFSM.States
{
    
    public class GameStateGreenhouseInProgress : GameBaseState
    {
        private PlantPuzzle _plantPuzzle;
        public override void EnterState(GameStateManager context)
        {
            _plantPuzzle = GameObject.FindFirstObjectByType<PlantPuzzle>();
            /* PlantPuzzle.OnPuzzleSolved += () =>
            
                 context.SwitchState(context.GameStates.LoungePhase2);
                 Debug.Log("switched GameState");
             };*/
        }

        public override void UpdateState(GameStateManager context)
        {
            if (_plantPuzzle.PuzzleSolved)
            {
                context.SwitchState(context.GameStates.LoungePhase2);
                Debug.Log("switched GameState");
            }
        }

        public override void ExitState(GameStateManager context)
        {
           // PlantPuzzle.OnPuzzleSolved = null;
        }
    }
}
