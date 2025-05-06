using System;
using UnityEngine;

namespace Models
{
    public class DoorAnchor : MonoBehaviour {
        public string doorID;
        public event Action<Collider> OnTriggerEntered;
        public event Action<Collider> OnTriggerExited;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEntered?.Invoke(other);
            Debug.Log("OnTriggerEntered");
        }
        
        private void OnTriggerExit(Collider other)
        {
            OnTriggerExited?.Invoke(other);
            Debug.Log("OnTriggerExited");

        }
    }
}