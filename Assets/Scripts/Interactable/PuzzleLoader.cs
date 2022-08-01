using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleLoader : MonoBehaviour
{
    [SerializeField]
    private string _sceneToLoad;
    [SerializeField]
    private PuzzleSO _PuzzleToLoad;
    [SerializeField]
    private GameObject _PlayerToLoad;

    public void SwitchToPuzzleScene()
    {
        UnloadScene();
    }

    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()).completed += LoadScene;
    }
    
    public void LoadScene(AsyncOperation obj)
    {

        SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive).completed += OnSceneLoaded;
    }

    private void OnSceneLoaded(AsyncOperation obj)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneToLoad));
        LoadPuzzle();
    }

    private void LoadPuzzle()
    {
        //TODO: LoadPuzzleFrom Scriptable Object
        SpawnPlayerAtPosition(_PuzzleToLoad.playerSpawnPosition);
    }

    private void SpawnPlayerAtPosition(Vector3Int spawnPosition)
    {
        Instantiate(_PlayerToLoad, spawnPosition, Quaternion.identity);
    }
}