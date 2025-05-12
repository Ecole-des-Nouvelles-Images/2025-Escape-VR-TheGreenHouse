using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using DG.Tweening;

using Code.Scripts.Source.Managers;

namespace Code.Scripts.Source.GameFSM.States
{
    [Serializable]
    public class GameStatePause : GameBaseState
    {
        [SerializeField] private GameObject _pauseUI;
        [SerializeField] private float _pauseUIAnimationDuration = 0.5f;
        [SerializeField] [Min(0f)] private float _pauseUIAnimationScale = 0.5f;
        [SerializeField] private Ease _pauseAnimationEasing;
        [Space]
        [SerializeField] private Volume _postRenderVolume;
        [SerializeField] private float _exposureAnimationDuration = 2f;
        [SerializeField] [Range(-10, 0)] private float _exposureToneDownIntensity = -2f;

        private ColorAdjustments _colorAdjustorModule;

        private List<XRBaseInteractable> _currentSceneInteractable = new ();

        public override void EnterState(GameStateManager context)
        {
            Debug.Log("Pause state entered!");
            context.GamePaused = true;

            if (!_postRenderVolume)
                throw new NullReferenceException("[GameStatePause] Missing reference for _postRenderVolume.\n> Check if the post-process volume is assigned in the inspector.");

            if (!_postRenderVolume.profile.TryGet(out _colorAdjustorModule))
                throw new Exception("[GameStatePause] Unable to get {ColorAdjustments} post-process profile's module");

            UpdateCurrentXRInteractable();
            EnableXRInteractable(false);

            DOTween.To(
                () => _colorAdjustorModule.postExposure.value,
                x => _colorAdjustorModule.postExposure.value = x,
                _exposureToneDownIntensity, _exposureAnimationDuration
            );

            _pauseUI.SetActive(true);
            _pauseUI.transform.DOScale(_pauseUIAnimationScale, _pauseUIAnimationDuration).SetEase(Ease.InOutBounce);
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
            EnableXRInteractable(true);
            Debug.Log("Pause state exited!");
        }

        private void EnableXRInteractable(bool enable)
        {
            if (_currentSceneInteractable.Count > 0)
            {
                for (int i = 0; i < _currentSceneInteractable.Count; i++)
                    _currentSceneInteractable[i].enabled = enable;
            }
        }

        private void UpdateCurrentXRInteractable()
        {
            if (_currentSceneInteractable.Count == 0)
            {
                GameObject[] activeObjects = SceneLoader.Instance.CurrentScene.SceneObject.GetRootGameObjects();

                foreach (GameObject item in activeObjects)
                    _currentSceneInteractable.AddRange(item.GetComponentsInChildren<XRBaseInteractable>());
            }
        }
    }
}
