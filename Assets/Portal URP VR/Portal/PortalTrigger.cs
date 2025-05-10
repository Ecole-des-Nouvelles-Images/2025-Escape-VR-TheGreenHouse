using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Serialization;

public class PortallTrigger : MonoBehaviour
{
   
    public bool IsActive { get; set; } = true;
    [SerializeField] Transform _newInPortal,_newOutPortal;
    private bool _isActive;
    
    private void Awake()
    {
        IsActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("collide portal");
            if (!IsActive) return;
            Transform playerTransform = other.GetComponentInParent<XROrigin>().transform;
            PortalController.OnTriggerEntered?.Invoke(playerTransform,_newInPortal,_newOutPortal);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsActive = true;
    }
}
