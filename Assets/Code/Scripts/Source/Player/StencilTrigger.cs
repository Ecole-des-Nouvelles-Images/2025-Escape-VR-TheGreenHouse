using System;
using Code.Scripts.Source.Managers;
using Code.Scripts.Source.Types;
using UnityEngine;

namespace Code.Scripts.Source.Player
{
    public class StencilTrigger : MonoBehaviour
    {
        [Header("Assign in Inspector")]
        [Tooltip("The room GameObject whose original layer will be restored.")]
        [SerializeField]
        private GameObject previousRoom;

        [Tooltip("The room GameObject that will switch to Default layer.")] [SerializeField]
        private GameObject nextRoom;

        private int previousRoomOriginalLayer;
        private int defaultLayer;

        private RoomLayerManager manager;

        private void Awake()
        {
            previousRoomOriginalLayer = previousRoom.layer;
            defaultLayer = LayerMask.NameToLayer("Default");
            if (defaultLayer == -1)
                Debug.LogError("Default layer not found. Check your project layers.");

            manager = FindObjectOfType<RoomLayerManager>();
            if (manager == null)
                Debug.LogError("No RoomLayerManager found in scene. Please add one.");
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            manager.RequestLayerChange(this);
        }
        
        public void RestorePreviousRoomLayer()
        {
            Debug.Log("RestoreLayer");
            SetLayerRecursively(previousRoom, previousRoomOriginalLayer);
        }
        
        public void SetNextRoomDefault()
        {
            Debug.Log("SetLayer");
            SetLayerRecursively(nextRoom, defaultLayer);
        }

        private void SetLayerRecursively(GameObject obj, int layer)
        {
            obj.layer = layer;
            foreach (Transform child in obj.transform)
                SetLayerRecursively(child.gameObject, layer);
        }
    }
}