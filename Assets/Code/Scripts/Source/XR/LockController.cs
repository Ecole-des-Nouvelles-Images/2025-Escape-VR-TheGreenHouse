using JetBrains.Annotations;
using UnityEngine;


namespace Code.Scripts.Source.XR
{
    public class LockController : MonoBehaviour
    {
        [SerializeField] private Transform _selectedTransform;
        [SerializeField] private Transform _playerCameraTransform;
        [SerializeField] XRLockWheel[] _lockWheels;
        [SerializeField] private string correctCode = "2736";

        
        private Vector3 _initialPosition;
        private Quaternion _initialRotation;
        private string _currentCode;
        private bool _zoomed;

        private void Start()
        {
            _initialPosition = transform.position;
            _initialRotation = transform.rotation;
            
            
            foreach (XRLockWheel lockWheel in _lockWheels)
            {
                lockWheel.onValueChange.AddListener(value => OnWheelMoved());
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

        private void OnWheelMoved()
        {
            _currentCode = "";

            foreach (XRLockWheel lockWheel in _lockWheels)
            {
                int number = Mathf.RoundToInt(lockWheel.value * 9f); 
                _currentCode += number.ToString();
            }

            Debug.Log("Voici le code actuel : " + _currentCode);
            VerifyCode();
        }

        
        private void VerifyCode()
        {
            if (_currentCode == correctCode)
            {
                UnlockLock();
            }
        }

        private void UnlockLock()
        {
            Debug.Log("Unlocking lock");
            gameObject.SetActive(false);
        }
    }
}
