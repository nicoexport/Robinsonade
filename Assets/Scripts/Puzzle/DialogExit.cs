using Architecture;
using Puzzle;
using UnityEngine;

public class DialogExit : PuzzleRoomExit
{
    public override void Exit()
    {
        DialogLevelManager.Instance.CurrentDialogLevelUI.gameObject.SetActive(false);
        SceneLoader.Instance.LoadScene(SceneLoader.Instance.last_RealWorldScene_Index);
    }
}
