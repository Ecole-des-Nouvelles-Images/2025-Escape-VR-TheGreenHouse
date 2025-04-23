using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Scripts.Source.XR
{
    public class LockZoom : MonoBehaviour
    {
        private Vector3 _initialPosition;
        private Quaternion _initialRotation;
        [SerializeField] private Transform _selectedTransform;
        [SerializeField] private Transform _playerCameraTransform;
        
        private bool _zoomed;
        
        private void Start()
        {
            _initialPosition = transform.position;
            _initialRotation = transform.rotation;
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
    }
}
