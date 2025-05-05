using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public static event Action<string, int> Rotated;
    
    private bool _coroutineAllowed;
    private int _numberShown;

    private void Start()
    {
        _coroutineAllowed = true;
        _numberShown = 0;
    }

    [UsedImplicitly]
    private void OnWheelInteract()
    {
        if (_coroutineAllowed)
        {
            StartCoroutine(RotateWheel());
        }
    }

    private IEnumerator RotateWheel()
    {
        _coroutineAllowed = false;
        for (int i = 0; i < _numberShown; i++)
        {
            transform.Rotate(0f, 0f, 3f);
            yield return new WaitForSeconds(0.01f);
        }
        _coroutineAllowed = true;
        _numberShown += +1;
        if (_numberShown > 9)
        {
            _numberShown = 0;
        }

        Rotated(name, _numberShown);
    }
}
