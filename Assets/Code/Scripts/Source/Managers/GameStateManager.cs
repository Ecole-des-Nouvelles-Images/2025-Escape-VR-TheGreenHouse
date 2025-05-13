using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Code.Scripts.Source.GameFSM;
using Code.Scripts.Source.GameFSM.States;

namespace Code.Scripts.Source.Managers
{
    public class GameStateManager: MonoBehaviour
    {
        [field: SerializeField] public GameStates GameStates { get; private set; } = new();
        public GameBaseState CurrentState { get; private set; }

        public bool GamePaused { get; set; }

        public bool EnableStateExit { get; set; } = true;

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
            if (CurrentState != null && this.EnableStateExit)
                CurrentState.ExitState(this);

            CurrentState = newState;

            newState.EnterState(this);
        }
    }
}
