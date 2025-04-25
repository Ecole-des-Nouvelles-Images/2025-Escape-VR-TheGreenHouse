using System;
using System.Collections.Generic;
using Code.Scripts.Source.Types;
using UnityEngine;

namespace Code.Scripts.Source.Managers
{
    public class LayerManager : MonoBehaviour
    {

        private LayerMask _viewLayer;
        private static readonly Dictionary<Room, LayerMask> RoomsLayers = new Dictionary<Room, LayerMask>()
        {
            { Room.Hall, GetLayerHelper(Room.Hall, Room.Corridor1)},
            { Room.Lounge, GetLayerHelper(Room.Lounge, Room.Laboratory, Room.Corridor2)},
            { Room.Backyard, GetLayerHelper(Room.Backyard, Room.Greenhouse, Room.Corridor3)},
            { Room.Greenhouse, GetLayerHelper(Room.Greenhouse, Room.Backyard)},
            { Room.Laboratory, GetLayerHelper(Room.Laboratory, Room.Lounge)},
            { Room.Corridor1, GetLayerHelper(Room.Corridor1, Room.Hall, Room.Corridor2) },
            { Room.Corridor2, GetLayerHelper(Room.Corridor2, Room.Lounge, Room.Corridor1, Room.Corridor3) },
            { Room.Corridor3, GetLayerHelper(Room.Corridor3, Room.Backyard, Room.Corridor2) }
        };
    
         private static Camera _playerCamera;

         private void Awake()
         {
             _playerCamera = Camera.main;
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

        public static void ChangeRoom(Room destinationRoom)
        {
            if (RoomsLayers.TryGetValue(destinationRoom, out var layer))
            {
                _playerCamera.cullingMask = layer;
            }
        }
    }
}
