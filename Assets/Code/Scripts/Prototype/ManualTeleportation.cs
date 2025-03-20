using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.Prototype
{
    public class ManualTeleportation : MonoBehaviour
    {
        public enum Rooms
        {
            Hall, Lounge
        }

        public Transform XROrigin;
        public Rooms CurrentRoom = Rooms.Hall;

        public Transform RoomSelector;
        public CanvasGroup FadeCanvasGroup;

        public void TeleportPlayer(Transform destination)
        {
            if (!XROrigin || !destination)
                Debug.LogWarning($"GameObject {name}: XROrigin or destination is not set");

            FadeCanvasGroup.DOFade(1f, 2).OnComplete(() => {
                XROrigin.position = destination.position;
                XROrigin.rotation = destination.rotation;
                FadeCanvasGroup.DOFade(0, 2);
            });
        }
    }
}
