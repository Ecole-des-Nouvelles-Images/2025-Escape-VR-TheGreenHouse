using System;
using System.Collections;
using UnityEngine;

namespace Code.Scripts.Source.XR
{
    public class WheelRotation : MonoBehaviour
    {
        public static event Action<string, int> OnRotated;

        [SerializeField] private float _animDelay = 0.5f;
        [SerializeField] private float _xAngle, _yAngle, _zAngle;
        private Coroutine _coroutine;
        private int _numberShown;

        private void Start()
        {
            _numberShown = 0;
        }
    
        [ContextMenu("Rotate Wheel")]
        public void OnWheelInteract()
        {
            if (_coroutine != null) return;
        
            _coroutine = StartCoroutine(RotateWheel());
        }

        private IEnumerator RotateWheel()
        {
            float t = 0;
        
            Quaternion initialRotation = transform.rotation;
            _zAngle += -36;
            if (_xAngle <= -360)
                _xAngle += 360;
            Vector3 targetAngle = new Vector3(_xAngle, _yAngle, _zAngle);
            Quaternion targetRotation = Quaternion.Euler(targetAngle);

            while (t < 1)
            {
                t += Time.deltaTime / _animDelay;
                transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
                yield return null;
            }
        
            _numberShown++;
            if (_numberShown > 9)
            {
                _numberShown = 0;
            }
        
            OnRotated?.Invoke(name, _numberShown);
            _coroutine = null;
        }

        /*private IEnumerator RotateWheel()
    {
        Debug.Log("Rotating Wheel");
        for (int i = 0; i < 11; i++)
        {
            Vector3 eulerAngles = transform.rotation.eulerAngles;
            eulerAngles += new Vector3(36f, 0, 0f);
            transform.rotation = Quaternion.Euler(eulerAngles);
            // transform.Rotate(3f, 0f, 0f, Space.Self);
            yield return new WaitForSeconds(0.01f);
        }
        _numberShown++;
        if (_numberShown > 9)
        {
            _numberShown = 0;
        }

        OnRotated?.Invoke(name, _numberShown);
    }*/
    }
}
