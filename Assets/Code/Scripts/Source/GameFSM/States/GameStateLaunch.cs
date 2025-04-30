using System.Collections;
using UnityEngine;

using Code.Scripts.Source.Managers;

namespace Code.Scripts.Source.GameFSM.States
{
    public class GameStateLaunch : GameBaseState
    {
        public override void EnterState(GameStateManager context)
        {
            context.StartCoroutine(HelloWithDelay(5));
        }

        public override void UpdateState(GameStateManager context)
        {

        }

        public override void ExitState(GameStateManager context)
        {

        }


        private IEnumerator HelloWithDelay(int delay)
        {
            Debug.Log("Hello from Launch state!");

            for (int i = 0; i <= delay; i++)
            {
                Debug.Log("Transition to HallIntro in... " + (delay - i));
                yield return new WaitForSeconds(1);
            }
        }
    }
}
