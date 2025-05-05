using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Code.Scripts.Source.GameFSM;
using Code.Scripts.Source.GameFSM.States;

namespace Code.Scripts.Source.Managers
{
    public class GameStateManager: MonoBehaviour
    {
        #region Serialized Fields

        [Header("Lounge")]
        public List<string> CorrectBookPlacement ;

        #endregion

        public GameBaseState CurrentState { get; private set; }
        public GameStates GameStates { get; private set; } = new();

        public bool GamePaused { get; set; }

        private InputAction _menuButton, _menuButtonInteraction;

        public static Action OnFirstSceneLoaded;

        private void Awake()
        {
            _menuButton = InputSystem.actions.FindAction("XRI Left/MenuButton", true);
            _menuButtonInteraction = InputSystem.actions.FindAction("XRI Left Interaction/MenuButton", true);
        }

        private void Start()
        {
            CurrentState = GameStates.Uninitialized;
            CurrentState.EnterState(this);
        }

        private void OnEnable()
        {
            OnFirstSceneLoaded += InitializeFSM;
        }

        private void OnDisable()
        {
            OnFirstSceneLoaded -= InitializeFSM;
        }

        private void OnApplicationQuit()
        {
            Destroy(this);
        }

        private void Update()
        {
            if (_menuButton.WasPressedThisFrame() || _menuButtonInteraction.WasPressedThisFrame())
            {
                SwitchState(GameStates.Pause);
                return;
            }

            CurrentState.UpdateState(this);
        }

        private void InitializeFSM()
        {
            SwitchState(GameStates.MainMenu);
        }

        public void SwitchState(GameBaseState newState)
        {
            if (CurrentState != null)
                CurrentState.ExitState(this);

            CurrentState = newState;

            newState.EnterState(this);
        }
    }
}
