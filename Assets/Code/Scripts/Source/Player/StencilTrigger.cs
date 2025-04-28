using System;
using Code.Scripts.Source.Types;
using UnityEngine;

namespace Code.Scripts.Source.Player
{
    public class StencilTrigger : MonoBehaviour
    {
        [SerializeField] private Room _room;
        public event Action<Room> OnTriggerEntered;
        public event Action<Room> OnTriggerExited;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            OnTriggerEntered?.Invoke(_room);
            Debug.Log("OnTriggerEntered");
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            OnTriggerExited?.Invoke(_room);
            Debug.Log("OnTriggerExited");

        }
    }
}