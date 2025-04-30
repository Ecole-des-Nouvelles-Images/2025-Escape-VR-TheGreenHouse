using Code.Scripts.Source.GameFSM.States;

namespace Code.Scripts.Source.GameFSM
{
    public class GameStates
    {
        public GameStateLaunch Launch { get; private set; } = new();
        public GameStatePause Pause { get; private set; } = new();

        public GameStateHallIntro HallIntro { get; private set; } = new();
        public GameStateHallInProgress HallInProgress { get; private set; } = new();
        public GameStateHallResolved HallResolved { get; private set; } = new();

        public GameStateLoungeIntro LoungeIntro { get; private set; } = new();
        public GameStateLoungePhase1 LoungePhase1 { get; private set; } = new();
        public GameStateLoungePhase2 LoungePhase2 { get; private set; } = new();
        public GameStateLoungeResolved LoungeResolved { get; private set; } = new();

        public GameStateBackyardTransition BackyardTransition { get; private set; } = new();
        public GameStateGreenhouseIntro GreenhouseIntro { get; private set; } = new();
        public GameStateGreenhouseInProgress GreenhouseInProgress { get; private set; } = new();
        public GameStateGreenhouseResolved GreenhouseResolved { get; private set; } = new();

        public GameStateLaboratoryIntro LaboratoryIntro { get; private set; } = new();
        public GameStateLaboratoryPhase1 LaboratoryPhase1 { get; private set; } = new();
        public GameStateLaboratoryPhase2 LaboratoryPhase2 { get; private set; } = new();
        public GameStateLaboratoryResolved LaboratoryResolved { get; private set; } = new();

        public GameStateEscapeRun Escape { get; private set; } = new();
        public GameStateGameOver GameOver { get; private set; } = new();
    }
}
