using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Architecture
{
    public class InitSceneLoader : Singleton<InitSceneLoader>
    {
        const int INIT_SCENE_BUILDINDEX = 0;
        const int MAIN_MENU_SCENE_BUILDINDEX = 1;

        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(SceneSetupEnumerator());
        }

        private IEnumerator SceneSetupEnumerator()
        {
            Time.timeScale = 0f;

#if UNITY_EDITOR
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case INIT_SCENE_BUILDINDEX:
                    yield return SceneManager.LoadSceneAsync(MAIN_MENU_SCENE_BUILDINDEX, LoadSceneMode.Additive);
                    SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(MAIN_MENU_SCENE_BUILDINDEX));
                    break;

                default:
                    SceneManager.LoadScene(INIT_SCENE_BUILDINDEX, LoadSceneMode.Additive);
                    break;
            }
#else
            yield return SceneManager.LoadScene(MAIN_MENU_SCENE_BUILDINDEX, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(MAIN_MENU_SCENE_BUILDINDEX));
#endif
            Time.timeScale = 1f;
        }
    }
}
