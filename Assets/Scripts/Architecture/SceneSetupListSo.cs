#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

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

        public void Remove(SceneSetup s)
        {
            if (List.Contains(s))
                List.Remove(s);
        }

        public void Clear()
        {
            List.Clear();
        }
    }
}
#endif