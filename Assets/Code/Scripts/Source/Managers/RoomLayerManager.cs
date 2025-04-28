using Code.Scripts.Source.Player;
using UnityEngine;

namespace Code.Scripts.Source.Managers
{
    public class RoomLayerManager : MonoBehaviour
    {
        public void RequestLayerChange(StencilTrigger stencilTrigger)
        {
            stencilTrigger.RestorePreviousRoomLayer();
            stencilTrigger.SetNextRoomDefault();
        }
    }
}
