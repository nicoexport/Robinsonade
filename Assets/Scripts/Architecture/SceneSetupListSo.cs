#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture
{
    [CreateAssetMenu(fileName = "new Scene Setup", menuName = "Scriptable Objects/Scene Setup List", order = 0)]
    public class SceneSetupListSo : ScriptableObject
    {
        public List<SceneSetup> List { get; private set; } = new List<SceneSetup>();

        public void Add(SceneSetup s)
        {
            List.Add(s);
        }

        public void Add(string sceneName)
        {
            SceneSetup sceneToAdd = new SceneSetup();
            sceneToAdd.path = SceneManager.GetSceneByName(sceneName).path;
            List.Add(sceneToAdd);
        }

        public void Remove(SceneSetup s)
        {
            if (List.Contains(s))
                List.Remove(s);
        }

        public void Remove(string sceneName)
        {
            SceneSetup sceneToRemove = List.Find(s => s.path == SceneManager.GetSceneByName(sceneName).path);
            if (sceneToRemove != null)
                List.Remove(sceneToRemove);
        }

        public void Clear()
        {
            List.Clear();
        }
    }
}
#endif