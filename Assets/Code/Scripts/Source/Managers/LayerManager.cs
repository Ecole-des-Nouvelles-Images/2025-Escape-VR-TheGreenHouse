using System;
using System.Collections.Generic;
using Code.Scripts.Source.Player;
using Code.Scripts.Source.Types;
using UnityEngine;

namespace Code.Scripts.Source.Managers
{
    public class LayerManager : MonoBehaviour
    {
        public static Dictionary<Room, LayerMask> RoomsLayers;

        [SerializeField] private StencilTrigger _stencilTrigger;
        private static Camera _playerCamera;

        private void OnEnable()
        {
            _stencilTrigger.OnTriggerEntered += ChangeRoom;
        }
         
        private void OnDisable()
        {
            _stencilTrigger.OnTriggerEntered -= ChangeRoom;
        }
        
        private void Awake()
        {
            _playerCamera = Camera.main;
            InitializeRoomsLayers();
        }

        private void InitializeRoomsLayers()
        {
            RoomsLayers = new Dictionary<Room, LayerMask>
            {
                { Room.Hall, GetLayerHelper(Room.Hall, Room.Corridor1) },
                { Room.Lounge, GetLayerHelper(Room.Lounge, Room.Laboratory, Room.Corridor2) },
                { Room.Backyard, GetLayerHelper(Room.Backyard, Room.Greenhouse, Room.Corridor3) },
                { Room.Greenhouse, GetLayerHelper(Room.Greenhouse, Room.Backyard) },
                { Room.Laboratory, GetLayerHelper(Room.Laboratory, Room.Lounge) },
                { Room.Corridor1, GetLayerHelper(Room.Corridor1, Room.Hall, Room.Corridor2) },
                { Room.Corridor2, GetLayerHelper(Room.Corridor2, Room.Lounge, Room.Corridor1, Room.Corridor3) },
                { Room.Corridor3, GetLayerHelper(Room.Corridor3, Room.Backyard, Room.Corridor2) }
            };
        }

        private static LayerMask GetLayerHelper(params Room[] roomNames)
        {
            LayerMask layerMask = 0;
            foreach (Room room in roomNames)
            {
                layerMask |= 1 << LayerMask.NameToLayer(room.ToString());
            }

            return layerMask;
        }

        private void ChangeRoom(Room destinationRoom)
        {
            if (RoomsLayers != null && RoomsLayers.TryGetValue(destinationRoom, out var mask))
            {
                _playerCamera.cullingMask = mask;
            }
        }
    }
}