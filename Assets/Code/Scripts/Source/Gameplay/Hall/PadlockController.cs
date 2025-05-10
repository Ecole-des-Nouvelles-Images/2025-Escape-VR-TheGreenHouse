using DG.Tweening;
using UnityEngine;

namespace Code.Scripts.Source.Gameplay.Hall
{
    public class PadlockController : MonoBehaviour
    {
        [SerializeField] private Transform _padlockPrefab; 
        [SerializeField] private Transform _zoomTargetPoint;
        [SerializeField] private Vector3 _zoomedScale = new Vector3(2, 2, 2);
        [SerializeField] private float _zoomDuration = 0.5f;

        private Vector3 _originalScale;
        private Vector3 _originalPosition;
        private bool _isZoomed;

        private void Start()
        {
            _originalScale = _padlockPrefab.localScale;
            _originalPosition = _padlockPrefab.position;
        }

        [ContextMenu("Zoom")]
        public void Zoom()
        {
            if (!_isZoomed)
            {
                _padlockPrefab.DOMove(_zoomTargetPoint.position, _zoomDuration);
                _padlockPrefab.DOScale(_zoomedScale, _zoomDuration);
            }
            else
            {
                _padlockPrefab.DOMove(_originalPosition, _zoomDuration);
                _padlockPrefab.DOScale(_originalScale, _zoomDuration);
            }

            _isZoomed = !_isZoomed;
        }
    }
}