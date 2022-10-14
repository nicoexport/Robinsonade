using Architecture;
using Puzzle;
using UnityEngine;

public class DialogExit : PuzzleRoomExit
{
    [SerializeField]
    private int _sceneToLoadIndex;

    public override void Exit()
    {
        DialogLevelManager.Instance.CurrentDialogLevelUI.gameObject.SetActive(false);
        SceneLoader.Instance.LoadScene(_sceneToLoadIndex);
    }
}
