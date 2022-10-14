using Architecture;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    private Scene _currentScene;
    private int _sceneToLoad;

    private SceneFader _sceneFader;

    protected override void Awake()
    {
        base.Awake();
        _sceneFader = GetComponent<SceneFader>();
    }

    public void LoadScene(int sceneToLoad)
    {
        _sceneToLoad = sceneToLoad;
        _currentScene = SceneManager.GetActiveScene();

        InputManager.Instance.PlayerInputActions.Disable();

        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_sceneFader.FadeOut());
        yield return waitTime;
        UnloadScene();
    }

    private void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(_currentScene).completed += OnUnloadCompleted;
        InitSceneLoader.Instance.RemoveFromScenes(_currentScene.name);
    }

    private void OnUnloadCompleted(AsyncOperation asyncOperation)
    {
        SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive).completed += OnLoadCompleted;
    }

    private void OnLoadCompleted(AsyncOperation asyncOperation)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_sceneToLoad));
        InitSceneLoader.Instance.AddToScenes(SceneManager.GetSceneByBuildIndex(_sceneToLoad).name);

        InputManager.Instance.PlayerInputActions.Enable();

        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_sceneFader.FadeIn());
        yield return waitTime;
    }
}
