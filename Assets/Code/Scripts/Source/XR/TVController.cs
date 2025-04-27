using System;
using Code.Scripts.Source.XR;
using UnityEngine;

public class TVController : MonoBehaviour
{
    private Animator _animator;
    private XRSocketTagInteractor _socketTagInteractor;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _socketTagInteractor = GetComponentInChildren<XRSocketTagInteractor>();
    }

    private void OnEnable()
    {
        
    }
    
    
    public void InsertCassette()
    {
        
    }
}
