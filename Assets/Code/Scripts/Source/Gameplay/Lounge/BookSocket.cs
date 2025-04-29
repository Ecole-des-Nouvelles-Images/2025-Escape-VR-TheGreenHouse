using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BookSocket : MonoBehaviour
{
    public static event Action OnAnySocketChanged;

    private XRSocketInteractor _socket;

    private void Awake() => _socket = GetComponent<XRSocketInteractor>();

    private void OnEnable()
    {
        _socket.selectEntered.AddListener(_ => OnAnySocketChanged?.Invoke());
        _socket.selectExited.AddListener(_ => OnAnySocketChanged?.Invoke());
    }

    private void OnDisable()
    {
        _socket.selectEntered.RemoveAllListeners();
        _socket.selectExited.RemoveAllListeners();
    }
    
    
    /*private void OnEnable()
    {
        _socket.selectEntered.AddListener(OnBookPlaced);
        _socket.selectExited.AddListener(OnBookRemoved);
    }

    private void OnDisable()
    {
        _socket.selectEntered.RemoveListener(OnBookPlaced);
        _socket.selectExited.RemoveListener(OnBookRemoved);
    }

    private void OnBookPlaced(SelectEnterEventArgs args)
    {
        OnAnySocketChanged?.Invoke();
    }

    private void OnBookRemoved(SelectExitEventArgs args)
    {
        OnAnySocketChanged?.Invoke();
    }
}*/
}
