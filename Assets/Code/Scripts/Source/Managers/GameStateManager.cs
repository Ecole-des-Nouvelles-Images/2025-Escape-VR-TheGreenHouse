using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Code.Scripts.Source.GameFSM;
using Code.Scripts.Source.GameFSM.States;
using Code.Scripts.Utils;

namespace Code.Scripts.Source.Managers
{
    public class GameStateManager: MonoBehaviourSingleton<GameStateManager>
    {
        [field: SerializeField] public GameStates GameStates { get; private set; } = new();
        public GameBaseState CurrentState { get; private set; }
        public GameBaseState PreviousState { get; private set; }

        public bool GamePaused { get; set; }

        private InputAction _menuButton, _menuButtonInteraction;

        public static Action OnFirstSceneLoaded;

        [Obsolete("\nThis is a debug input action and should not be used in production code.")]
        public InputAction PauseDebugInput; // TODO: DEBUG

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
            bool pauseButtonPressed = _menuButton.WasPressedThisFrame() || _menuButtonInteraction.WasPressedThisFrame() || PauseDebugInput.WasPressedThisFrame();

            if (pauseButtonPressed && !GamePaused)
            {
                SwitchState(GameStates.Pause, false, true);
                return;
            }

            CurrentState.UpdateState(this);
        }

        private void InitializeFSM()
        {
            SwitchState(GameStates.MainMenu);
        }

        // TODO: rework GameStates to initialize inside their first EnterState() instead of using a bypass here.
        public void SwitchState(GameBaseState newState, bool bypassEntry = false, bool bypassExit = false)
        {
            PreviousState = CurrentState;

            if (newState == null || CurrentState == newState)
            {
                Debug.LogWarning("[GameStateManager] Warning: switching to " + (newState == null ? "null state" : $"same state {{{CurrentState}}}"));
                return;
            }

            if (!bypassExit && CurrentState != null)
                CurrentState.ExitState(this);

            CurrentState = newState;

            newState.EnterState(this);
        }
    }
}
