using UnityEngine;

namespace _3Dynamite.Real_Ivy.SampleResources.Scripts
{
    public class PlaceTargetWithMouse : MonoBehaviour
    {
        public float surfaceOffset = 1.5f;
        public GameObject setTargetOn;

        private void Update()
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
				setTargetOn.transform.position = hit.point + hit.normal * surfaceOffset;
				setTargetOn.transform.forward = -hit.normal;
			}
		}
    }
}
