using DG.Tweening;
using UnityEngine;

namespace Code.Scripts.Source.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeScreen : MonoBehaviour
    {
        public float FadeDuration = 2f;
        [SerializeField] private AnimationCurve _fadeCurve;
        private CanvasGroup _canvasGroup;
        
        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            FadeOut();
        }

        public void FadeIn()
        {
            Fade(0,1, FadeDuration);
        }
    
        public void FadeOut()
        {
            Fade(1,0, FadeDuration);
        }
        
        private void Fade(float alphaIn, float alphaOut, float duration)
        { 
            _canvasGroup.alpha = alphaIn;
            _canvasGroup.DOFade(alphaOut, duration).SetEase(_fadeCurve);
        }
    }
}
                                    
