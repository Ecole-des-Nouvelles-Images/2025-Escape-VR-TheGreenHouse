using System;
using Code.Scripts.Source.Types;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Code.Scripts.Utils
{
    [Serializable]
    public class SceneField
    {
        [SerializeField] private Object _sceneAsset;

        public string SceneName => _sceneAsset.name;
        public Scene SceneObject => SceneManager.GetSceneByName(SceneName);
        public string ScenePath => SceneObject.path;
        public SceneType SceneType {
            get {
                switch (SceneName)
                {
                    case "MainMenu" or "Main Menu":
                        return SceneType.MainMenu;
                    case "Hall":
                        return SceneType.Hall;
                    case "Lounge":
                        return SceneType.Lounge;
                    case "Greenhouse":
                        return SceneType.Greenhouse;
                    case "Laboratory":
                        return SceneType.Laboratory;
                    default:
                        throw new Exception($"Unable to determine the SceneType of scene: {SceneName}. "+
                                            $"Verify that scene '{SceneName}' is correctly named.");
                }
            }
        }

        public static implicit operator string(SceneField sceneField)
        {
            return sceneField.SceneName;
        }

        public static implicit operator SceneField(Scene scene)
        {
            return new SceneField { _sceneAsset = AssetDatabase.LoadAssetAtPath<Object>(scene.path) };
        }

        public static implicit operator Scene(SceneField sceneField)
        {
            return sceneField.SceneObject;
        }

        public static implicit operator SceneField(string sceneName)
        {
            string path = SceneManager.GetSceneByName(sceneName).path;
            Object asset = AssetDatabase.LoadAssetAtPath<Object>(path);

            return new SceneField { _sceneAsset = asset };
        }
    }
}
