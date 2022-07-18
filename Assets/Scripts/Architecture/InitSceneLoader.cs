using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Architecture
{
    public class InitSceneLoader : Singleton<InitSceneLoader>
    {
        const int MAIN_MENU_SCENE_BUILDINDEX = 1;
        [SerializeField] private SceneSetupListSo _scenesToLoad;

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
                yield return SceneManager.LoadSceneAsync(setup.path, LoadSceneMode.Additive);
                if (setup.isActive)
                    SceneManager.SetActiveScene(SceneManager.GetSceneByPath(setup.path));
            }
#else
            yield return SceneManager.LoadScene(MAIN_MENU_SCENE_BUILDINDEX, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(MAIN_MENU_SCENE_BUILDINDEX));
#endif
            Time.timeScale = 1f;
        }
    }
}
