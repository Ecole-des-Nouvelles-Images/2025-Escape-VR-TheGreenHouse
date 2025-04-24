using JetBrains.Annotations;
using UnityEngine;

namespace Code.Scripts.Source.XR
{
    public class LockController : MonoBehaviour
    {
        [SerializeField] private Transform _selectedTransform;
        [SerializeField] private Transform _playerCameraTransform;
        [SerializeField] XRLockWheel[] _lockWheels;
        [SerializeField] private int[] _correctCode;
        
        private Vector3 _initialPosition;
        private Quaternion _initialRotation;
        private int[] _currentCode;
        private bool _zoomed;

        private void Start()
        {
            _initialPosition = transform.position;
            _initialRotation = transform.rotation;
            _currentCode = new int[_lockWheels.Length];

            
            for (int i = 0; i < _lockWheels.Length; i++)
            {
                int index = i;
                _lockWheels[i].onValueChange.AddListener(value => OnWheelMoved(index, value));
            }
        }
        
        [UsedImplicitly]
        public void ZoomLock()
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
        }

        private void OnWheelMoved(int wheelIndex, float wheelValue)
        {
            int wheelNumber = Mathf.RoundToInt(wheelValue * 9f);
            _currentCode[wheelIndex] = wheelNumber;
            Debug.Log($"OnWheelMoved {wheelNumber}");
            VerifyCode();
        }
        
        private void VerifyCode()
        {
            if (_correctCode == _currentCode)
            {
                UnlockLock();
                // GameEvents.OnCorrectCodeSubmitted.Invoke();
            }
        }

        private void UnlockLock()
        {
            Debug.Log("Unlocking lock");
            gameObject.SetActive(false);
        }
    }
}
