using Architecture;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    [HideInInspector]
    public int last_RealWorldScene_Index = 1; //load 1stFloor Scene if ther is no last "Realworld" Scene

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
        #if UNITY_EDITOR
        InitSceneLoader.Instance.RemoveFromScenes(_currentScene.name);
        #endif
    }

    private void OnUnloadCompleted(AsyncOperation asyncOperation)
    {
        SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive).completed += OnLoadCompleted;
    }

    private void OnLoadCompleted(AsyncOperation asyncOperation)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_sceneToLoad));
        #if UNITY_EDITOR
        InitSceneLoader.Instance.AddToScenes(SceneManager.GetSceneByBuildIndex(_sceneToLoad).name);
        #endif
        InputManager.Instance.PlayerInputActions.Enable();

        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_sceneFader.FadeIn());
        yield return waitTime;
    }
}
