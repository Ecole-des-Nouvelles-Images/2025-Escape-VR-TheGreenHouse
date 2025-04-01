using System.Collections;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Portal
{
    public class PortalColliderLayerTransition : MonoBehaviour
    { 
        [SerializeField] private GameObject roomToActivate;
        
        [SerializeField] private GameObject roomToDeactivate; 
        
        [SerializeField] private string activeLayerName = "Default";
        
        [SerializeField] private string inactiveLayerName = "Preview 1";
        
        [SerializeField] private float triggerCooldown = 1f;



        private bool isTriggered = false;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && !isTriggered)
            {
                Vector3 directionFromPortal = other.transform.position - transform.position;


                if (Vector3.Dot(directionFromPortal, transform.forward) > 0)
                {
                    isTriggered = true;

                    int newLayer = LayerMask.NameToLayer(activeLayerName);
                    int oldLayer = LayerMask.NameToLayer(inactiveLayerName);

                    if (roomToActivate != null)
                    {
                        SetLayerRecursively(roomToActivate, newLayer);
                    }

                    if (roomToDeactivate != null)
                    {
                        SetLayerRecursively(roomToDeactivate, oldLayer);
                    }

                    StartCoroutine(ResetTriggerAfterDelay(triggerCooldown));
                }
            }
        }

        private IEnumerator ResetTriggerAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            isTriggered = false;
        }

        private void SetLayerRecursively(GameObject obj, int newLayer)
        {
            obj.layer = newLayer;
            foreach (Transform child in obj.transform)
            {
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
    }
}
