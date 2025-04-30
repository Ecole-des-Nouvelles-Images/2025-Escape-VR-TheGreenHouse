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

        private InputAction _menuButton;

        private void Awake()
        {
            _menuButton = InputSystem.actions.FindAction("XRI Left/MenuButton", true);
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            CurrentState = GameStates.Launch;
            CurrentState.EnterState(this);
        }

        private void OnApplicationQuit()
        {
            Destroy(this);
        }

        private void Update()
        {
            if (_menuButton.WasPerformedThisFrame())
                SwitchState(GameStates.Pause);

            CurrentState.UpdateState(this);
        }

        public void SwitchState(GameBaseState newState)
        {
            CurrentState = newState;
            newState.EnterState(this);
        }
    }
}
