using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture
{
    public class InitSceneLoader : Singleton<InitSceneLoader>
    {
        const int MAIN_MENU_SCENE_BUILDINDEX = 1;
#if UNITY_EDITOR
        [SerializeField] private SceneSetupListSo _scenesToLoad;
#endif
        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(SceneSetupEnumerator());
        }

        private IEnumerator SceneSetupEnumerator()
        {
            Time.timeScale = 0f;
#if UNITY_EDITOR
            foreach (var setup in _scenesToLoad.List)
            {
                if (SceneManager.GetSceneByBuildIndex(0) != SceneManager.GetSceneByPath(setup.path))
                    yield return SceneManager.LoadSceneAsync(setup.path, LoadSceneMode.Additive);
                if (setup.isActive)
                    SceneManager.SetActiveScene(SceneManager.GetSceneByPath(setup.path));
            }
#else
            SceneManager.LoadScene(MAIN_MENU_SCENE_BUILDINDEX, LoadSceneMode.Additive);
            yield return null;
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(MAIN_MENU_SCENE_BUILDINDEX));
#endif
            Time.timeScale = 1f;
        }

        private void OnSceneUnloadComplete(AsyncOperation operation)
        {
            base.OnApplicationQuit();
        }

        AsyncOperation unload;
        protected override void OnApplicationQuit()
        {
#if UNITY_EDITOR
            foreach (var setup in _scenesToLoad.List)
            {
                SceneManager.UnloadScene(SceneManager.GetSceneByPath(setup.path));
            }
#endif
        }
    }
}
