using System;
using Code.Scripts.Source.GameFSM.States;
using Code.Scripts.Source.Managers;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Scripts.Source.Gameplay.Hall
{
    public class PadlockPuzzle : MonoBehaviour
    {
        public static Action<string, int> OnRotated;
        [SerializeField] private int[] _correctCode;
        [SerializeField] private int[] _currentCode;

        private void Start()
        {
            _currentCode = new int[] {0, 0, 0, 0};
        }

        private void OnEnable()
        {
            OnRotated += CheckResults;
        }

        private void OnDisable()
        {
            OnRotated -= CheckResults;
        }

        private void CheckResults(string wheelName, int wheelNumber)
        {
            switch (wheelName)
            {
                case "Wheel1":
                    _currentCode[0] = wheelNumber;
                    break;
                case "Wheel2":
                    _currentCode[1] = wheelNumber;
                    break;
                case "Wheel3":
                    _currentCode[2] = wheelNumber;
                    break;
                case "Wheel4":
                    _currentCode[3] = wheelNumber;
                    break;
            }

            if (_currentCode[0] == _correctCode[0] && _currentCode[1] == _correctCode[1] &&
                _currentCode[2] == _correctCode[2] && _currentCode[3] == _correctCode[3])
            {
                UnlockLock();
            }
        }
        
        private void UnlockLock()
        {
            GameStateHallInProgress.OnCodeFound?.Invoke();
        }
    }
}
