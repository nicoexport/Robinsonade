using Architecture;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    private Scene currentScene;
    private int sceneToLoad;

    public void LoadScene(int sceneToLoad)
    {
        this.sceneToLoad = sceneToLoad;
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive).completed += OnLoadCompleted;
    }

    private void OnLoadCompleted(AsyncOperation asyncOperation) 
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
