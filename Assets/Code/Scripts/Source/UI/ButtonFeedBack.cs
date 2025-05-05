using Code.Scripts.Source.Managers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.Scripts.Source.UI
{
    public class ButtonFeedBack : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float _soundVolume = 0.3f;
        [SerializeField] private float _feedbackDuration = 2f;

        private Button _button;
        private void Start()
        {
            _button = GetComponent<Button>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (AudioManager.Instance.gameObject.activeSelf)
                AudioManager.Instance.PlaySound(SoundType.Pressed,_soundVolume);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _button.transform.DOScale(1.1f, _feedbackDuration/2);

            if (AudioManager.Instance.gameObject.activeSelf)
                AudioManager.Instance.PlaySound(SoundType.Selected,_soundVolume);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _button.transform.DOScale(1f, _feedbackDuration/2);

            if (AudioManager.Instance.gameObject.activeSelf)
                AudioManager.Instance.PlaySound(SoundType.Canceled,_soundVolume);
        }

    }
}
