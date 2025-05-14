using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using VRTemplateAssets.Scripts;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _isUnLocked;
    [SerializeField] private float _openDoorHandleValue;
    [SerializeField] private float _resetHandleDuration = 1f;  
    private XRKnob _knob;
    private bool _handlePositionReset;
    private float _currentResetTime;

   
    private void Awake()
    {
        _knob = GetComponentInChildren<XRKnob>();
      
    }


    private void OnEnable()
    {
      //  _knob.selectEntered.AddListener(DoorHandleUpdate);
    }

    private void OnDisable()
    {
      //  _knob.selectEntered.RemoveListener(DoorHandleUpdate);
    }

    public void DoorHandleUpdate()
    {
        Debug.Log("DoorHandleUpdate");
        if (!Mathf.Approximately( _knob.value, _openDoorHandleValue)) return;
        if (_isUnLocked)
        {
            _handlePositionReset = true;
        }
        else
        {
            Debug.Log("DoorOpen");
        }
        
      
    }
    
    void Update()
    {
      ResetDoorHandle();
    }

    private void ResetDoorHandle( )
    {
        if (!_handlePositionReset) return;
        if (!Mathf.Approximately( _knob.value, _openDoorHandleValue)) 
        {
            _currentResetTime += Time.deltaTime;
            _knob.value = Mathf.Lerp(_knob.value, 1f, _currentResetTime / _resetHandleDuration);
            _handlePositionReset = false;
        }
    }
    
   
    
}
