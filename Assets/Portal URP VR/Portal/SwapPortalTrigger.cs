using System;
using UnityEngine;

public class SwapPortalTrigger : MonoBehaviour
{
    [SerializeField] Transform _newInPortal,_newOutPortal;
    private bool _isActive;

    private void Awake()
    {
        _isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("collide swapped");
            if (!_isActive) return;
            PortalController.OnPortalSwaped?.Invoke(_newInPortal,_newOutPortal);
            _isActive = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isActive = true;
    }
}
