using System;
using Code.Scripts.Source.GameFSM.States;
using Code.Scripts.Source.Managers;
using Code.Scripts.Utils;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Scripts.Source.UI
{
    public class PauseMenuController: MonoBehaviour
    {
        [SerializeField] private RectTransform _root;
        [SerializeField] private RectTransform _mainPanel;
        [SerializeField] private RectTransform _pausePanel;
        [Space]
        [SerializeField] private float _slideAnimationDuration = 1.5f;
        [SerializeField] private Ease _slideAnimationEasing;
        [Space]
        [SerializeField] private Button _buttonResume;
        [SerializeField] private Button _buttonOptions;
        [SerializeField] private Button _buttonMainMenu;
        [SerializeField] private Button _buttonExit;

        private bool _editOptions = false;

        private void Awake()
        {
            _root.localScale = Vector3.zero;
        }

        private void OnEnable()
        {
            _buttonResume.onClick.AddListener(ResumeGame);
            _buttonOptions.onClick.AddListener(ShowOptionsPanel);
            _buttonMainMenu.onClick.AddListener(ReloadGame);
            _buttonExit.onClick.AddListener(SceneLoader.Instance.ExitGame);
        }

        private void OnDisable()
        {
            _buttonResume.onClick.RemoveListener(ResumeGame);
            _buttonOptions.onClick.RemoveListener(ShowOptionsPanel);
            _buttonMainMenu.onClick.RemoveListener(ReloadGame);
            _buttonExit.onClick.RemoveListener(SceneLoader.Instance.ExitGame);
        }

        // ---

        public void ShowPausePanel()
        {
            _root.DOScale(1, 1f).SetEase(Ease.OutBounce);
        }

        public void HidePausePanel()
        {
            _root.DOScale(0, 1f).SetEase(Ease.InBounce);
        }

        // ---

        private void ResumeGame()
        {
            GameStateManager.Instance.SwitchState(GameStateManager.Instance.PreviousState, true, false);
        }

        private void ReloadGame()
        {
            SceneLoader.Instance.LoadSceneManual("Setup", LoadSceneMode.Single);
        }

        [ContextMenu("Test ShowOptionsPanel()")] // TODO: Fix Options panel not sliding correctly
        private void ShowOptionsPanel()
        {
            if (!_editOptions)
            {
                _editOptions = true;
                _pausePanel.DOKill();
                _mainPanel.DOKill();
                _pausePanel.DOAnchorPosX(_pausePanel.TargetAnchoredPosX(-2f), _slideAnimationDuration).SetEase(_slideAnimationEasing);
                _mainPanel.DOAnchorPosX(_mainPanel.TargetAnchoredPosX(-2f), _slideAnimationDuration).SetEase(_slideAnimationEasing);
            }
            else
            {
                _editOptions = false;
                _pausePanel.DOKill();
                _mainPanel.DOKill();
                _pausePanel.DOAnchorPosX(_pausePanel.TargetAnchoredPosX(-2f), _slideAnimationDuration).SetEase(_slideAnimationEasing);
                _mainPanel.DOAnchorPosX(_mainPanel.TargetAnchoredPosX(0f), _slideAnimationDuration).SetEase(_slideAnimationEasing);
            }
        }
    }
}
