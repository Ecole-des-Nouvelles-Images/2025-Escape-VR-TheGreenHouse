using System;
using Code.Scripts.Source.Managers;
using UnityEngine;
using UnityEngine.Playables;


namespace Code.Scripts.Source.GameFSM.States
{
    [Serializable]
    public class GameStateHallResolved: GameBaseState
    {
        [SerializeField] PlayableDirector _playableDirector;
        
        public override void EnterState(GameStateManager context)
        {
            PlayCinematic();
        }

        public override void UpdateState(GameStateManager context)
        {

        }

        public override void ExitState(GameStateManager context)
        {

        }
        
        public void PlayCinematic()
        {
            _playableDirector.Play();
        }
      
        public void StopCinematic()
        {
            _playableDirector.Stop();
        }
    }
}
