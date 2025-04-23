using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Scripts.Source.UI
{
    public class ButtonFeedBack : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
    
        
        
        public void OnPointerClick(PointerEventData eventData)
        {
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("OnPointerEnter");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
       
        }
    
    }
}
