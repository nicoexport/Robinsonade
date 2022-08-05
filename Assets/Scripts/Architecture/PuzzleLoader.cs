using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture
{
    public class PuzzleLoader : Singleton<PuzzleLoader>
    {
        private string _sceneToLoad;
        private PuzzleSO _puzzleToLoad;
        private GameObject _playerToLoad;

        public void SwitchToPuzzleScene(string sceneToLoad, PuzzleSO puzzleToLoad, GameObject playerToLoad)
        {
            _sceneToLoad = sceneToLoad;
            _puzzleToLoad = puzzleToLoad;
            _playerToLoad = playerToLoad;

            UnloadActiveScene();
        }


        public void UnloadActiveScene()
        {
            InitSceneLoader.Instance.RemoveFromScenes(SceneManager.GetActiveScene().name);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()).completed += LoadScene;
        }

        public void LoadScene(AsyncOperation obj)
        {
            SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive).completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperation obj)
        {
            InitSceneLoader.Instance.AddToScenes(SceneManager.GetSceneByName(_sceneToLoad).name);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneToLoad));
            LoadPuzzle(_puzzleToLoad);
        }

        private void LoadPuzzle(PuzzleSO puzzleToLoad)
        {
            //TODO: LoadPuzzleFrom Scriptable Object
            TileMapPainter tileMapPainter = FindObjectOfType<TileMapPainter>();
            foreach (var position in puzzleToLoad.wallTilePositions)
            {
                tileMapPainter.PaintTile(position,puzzleToLoad.wallTile);
            }
            SpawnPuzzleObjectAtPosition(puzzleToLoad.puzzleObjects);
            SpawnPlayerAtPosition(puzzleToLoad.playerSpawnPosition);
        }

        private void SpawnPuzzleObjectAtPosition(PuzzleObject[] puzzleObjects)
        {
            foreach (var puzzleObject in puzzleObjects)
            {
                Instantiate(puzzleObject.tileGameObject, puzzleObject.spawnPosition, Quaternion.identity);
            }
        }

        private void SpawnPlayerAtPosition(Vector3Int spawnPosition)
        {
            Instantiate(_playerToLoad, spawnPosition, Quaternion.identity);
        }
    }
}