using System.Collections;
using Code.Scripts.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.Source.Managers
{
    public class SceneTransitionManager : MonoBehaviourSingleton<SceneTransitionManager>
    {
        [SerializeField] private UI.FadeScreen _fadeScreen;
       
        public void LoadScene(string sceneName)
        {
            StartCoroutine(GoToSceneAsyncRoutine(sceneName));
        }
        
        IEnumerator GoToSceneAsyncRoutine(string sceneName)
        {
            _fadeScreen.FadeIn();
            //Launch the new scene
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;

            float timer = 0;
            while(timer <= _fadeScreen.FadeDuration && !operation.isDone)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            operation.allowSceneActivation = true;
        }
    }
    
}
