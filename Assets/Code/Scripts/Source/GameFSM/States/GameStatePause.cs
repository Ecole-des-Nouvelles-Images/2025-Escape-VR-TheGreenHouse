using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

using Code.Scripts.Source.Managers;

namespace Code.Scripts.Source.GameFSM.States
{
    [Serializable]
    public class GameStatePause : GameBaseState
    {
        [SerializeField] private Volume _postRenderVolume;
        [SerializeField] private float _exposureAnimationDuration = 2f;
        [SerializeField] [Range(-10, 0)] private float _exposureToneDownIntensity = -2f;

        private ColorAdjustments _colorAdjustorModule;

        public override void EnterState(GameStateManager context)
        {
            Debug.Log("Pause state entered!");
            context.GamePaused = true;

            if (!_postRenderVolume)
                throw new NullReferenceException("[GameStatePause] Missing reference for _postRenderVolume.\n> Check if the post-process volume is assigned in the inspector.");

            if (!_postRenderVolume.profile.TryGet(out _colorAdjustorModule))
                throw new Exception("[GameStatePause] Unable to get {ColorAdjustments} post-process profile's module");

            DOTween.To(
                () => _colorAdjustorModule.postExposure.value,
                x => _colorAdjustorModule.postExposure.value = x,
                _exposureToneDownIntensity, _exposureAnimationDuration
            );

            // TODO: disable all interactable
        }

        public override void UpdateState(GameStateManager context)
        {
            // if (context.PauseDebugInput.WasPressedThisFrame())
            // {
            //     context.SwitchState();
            // }
        }

        public override void ExitState(GameStateManager context)
        {
            DOTween.To(
                () => _colorAdjustorModule.postExposure.value,
                x => _colorAdjustorModule.postExposure.value = x,
                0, _exposureAnimationDuration
            );

            context.GamePaused = false;
            Debug.Log("Pause state exited!");
        }
    }
}
