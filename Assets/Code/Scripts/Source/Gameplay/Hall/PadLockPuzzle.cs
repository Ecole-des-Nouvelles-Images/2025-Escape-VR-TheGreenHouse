using System;
using JetBrains.Annotations;
using UnityEngine;


namespace Code.Scripts.Source.XR
{
    
    public class PadLockPuzzle : MonoBehaviour
    {
       // [SerializeField] private Transform _selectedTransform;
      //  [SerializeField] private Transform _playerCameraTransform;
        public static Action<string, int> OnRotated;
        
        [SerializeField] private int[] _correctCode;
        private Vector3 _initialPosition;
        private Quaternion _initialRotation;
        [SerializeField] private int[] _currentCode;
        private bool _zoomed;

        private void Start()
        {
            _initialPosition = transform.position;
            _initialRotation = transform.rotation;

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
            Debug.Log("check");
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
        
        [UsedImplicitly]
      /*  public void ZoomLock()
        {
            if (!_zoomed)
            {
                transform.position = _selectedTransform.position;
                _zoomed = true;
            }
            else
            {
                transform.position = _initialPosition;
                transform.rotation = _initialRotation;
                _zoomed = false;
            }
        }

        private void Update()
        {
            if (_zoomed) transform.LookAt(_playerCameraTransform);
        }*/
        

        private void UnlockLock()
        {
            Debug.Log("Unlocking lock");
            gameObject.SetActive(false);
        }
    }
}
