using System;
using System.Collections.Generic;
using Code.Scripts.Source.Managers;
using UnityEngine;

namespace Code.Scripts.Source.GameFSM.States
{
    [Serializable]
    public class GameStateLoungePhase2 : GameBaseState
    {
        [SerializeField] private List<string> _correctBookPlacement ;

        public override void EnterState(GameStateManager context)
        {

        }

        public override void UpdateState(GameStateManager context)
        {

           //action to check
        }

        public override void ExitState(GameStateManager context)
        {

        }
    }
}
