using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Source.Types;
using UnityEngine;
using UnityEngine.SceneManagement;

using Code.Scripts.Utils;

namespace Code.Scripts.Source.Managers
{
    public class SceneLoader : MonoBehaviourSingleton<SceneLoader>
    {
        [SerializeField] private List<SceneField> _sceneAssets;

        [Header("Transition settings")]
        [SerializeField] private float _fadeDuration = 2f;
        [SerializeField] private AnimationCurve _fadeCurve;

        public static Dictionary<SceneType, SceneField> SceneAssets { get; private set; } = new();

        private SceneTransitionManager _transitionManager;

        private SceneField _currentScene;

#if UNITY_EDITOR
        private void OnValidate()
        {
            SceneAssets.Clear();

            foreach (SceneField field in _sceneAssets)
                SceneAssets.Add(field.SceneType, field);
        }
#endif

        private void Awake()
        {
            _transitionManager = new(_fadeDuration, _fadeCurve);
            LoadScene(SceneType.MainMenu);
        }

        public void LoadScene(SceneType sceneType)
        {
            StartCoroutine(LoadSceneCoroutine(SceneAssets[sceneType], true, _fadeDuration));
        }

        public void SwitchScene(SceneType sceneType)
        {
            StartCoroutine(SwitchLoadedScene(SceneAssets[sceneType]));
        }

        /// <summary>
        /// Wait for the scene transition to complete and unloads the current scene before loading the specified one.
        /// </summary>
        /// <param name="scene"><c>SceneField</c> wrapper or convertable scene name string or <c>Scene</c> object.</param>
        /// <param name="loadAsActive">Should the scene be immediately marked as active when loaded or not. <c>true</c> by default.</param>
        /// <returns></returns>
        private IEnumerator SwitchLoadedScene(SceneField scene, bool loadAsActive = true)
        {
            _transitionManager.Crossfade.FadeIn();

            yield return new WaitForSeconds(_fadeDuration);

            if (_currentScene != null)
                yield return UnloadSceneCoroutine(_currentScene);

            yield return LoadSceneCoroutine(scene, loadAsActive);
        }

        /// <summary>
        /// Load asynchronously the specified scene, additively.
        /// </summary>
        /// <param name="scene"><c>SceneField</c> wrapper or convertable scene name string or <c>Scene</c> object.</param>
        /// <param name="loadAsActive">Should the scene be immediately marked as active when loaded or not. <c>true</c> by default.</param>
        /// <param name="minimumLoadTime">Optional delay before enabling the scene.</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Throws if an invalid scene has been specified.</exception>
        private IEnumerator LoadSceneCoroutine(SceneField scene, bool loadAsActive = true, float minimumLoadTime = 0f)
        {
            yield return new WaitForSeconds(minimumLoadTime);

            AsyncOperation asyncLoadOperation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

            if (asyncLoadOperation == null)
                throw new NullReferenceException($"LoadSceneAsync error: {scene} scene is null.");

            while (!asyncLoadOperation.isDone)
                yield return null;

            _currentScene = scene;
            asyncLoadOperation.allowSceneActivation = true;

            if (loadAsActive)
                SceneManager.SetActiveScene(scene);
        }

        /// <summary>
        /// Unload asynchronously the specified scene.
        /// </summary>
        /// <param name="scene"><c>SceneField</c> wrapper or convertable scene name string or <c>Scene</c> object.</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Throws if an invalid scene has been specified.</exception>
        private IEnumerator UnloadSceneCoroutine(SceneField scene)
        {
            AsyncOperation asyncUnloadOperation = SceneManager.UnloadSceneAsync(scene.SceneObject);

            if (asyncUnloadOperation == null)
                throw new NullReferenceException($"UnloadSceneAsync error: {scene} scene is null.");

            while (!asyncUnloadOperation.isDone)
            {
                yield return null;
            }
        }
    }
}
