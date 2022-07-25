using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Architecture
{
    public static class Bootstrap
    {
        [InitializeOnEnterPlayMode]
        static void SetOpenScenesForLoading()
        {
            var scenes = Resources.Load("SO_Scenes_To_Load") as SceneSetupListSo;
            if (scenes != null)
            {
                scenes.Clear();
                foreach (var setup in EditorSceneManager.GetSceneManagerSetup())
                {
                    scenes.Add(setup);
                }
            }
        }
    }
}
