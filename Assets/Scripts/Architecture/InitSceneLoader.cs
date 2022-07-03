using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Architecture
{
    public class InitSceneLoader : Singleton<InitSceneLoader>
    {
        const int INIT_SCENE_BUILDINDEX = 0;
        protected override void Awake()
        {
            base.Awake();
            Time.timeScale = 0f;

#if UNITY_EDITOR
            switch (SceneManager.GetActiveScene().buildIndex)
            {   
                case INIT_SCENE_BUILDINDEX:
                    break;

                default:
                    SceneManager.LoadScene(INIT_SCENE_BUILDINDEX, LoadSceneMode.Additive);
                    break;
            }
#endif
            Time.timeScale = 1f;
        }
    }
}
