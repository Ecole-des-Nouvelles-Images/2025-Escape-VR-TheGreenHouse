using System;
using System.Collections;
using UnityEngine;

using Code.Scripts.Source.Managers;

namespace Code.Scripts.Source.GameFSM.States
{
    [Serializable]
    public class GameStateLaunch : GameBaseState
    {
        public override void EnterState(GameStateManager context)
        {
            base.EnterState(context);
            context.SwitchState(context.GameStates.HallIntro);
        }

        public override void UpdateState(GameStateManager context)
        {

        }

        public override void ExitState(GameStateManager context)
        {

        }
    }
}
