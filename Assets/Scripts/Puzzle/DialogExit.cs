using System.Collections;
using System.Collections.Generic;
using Architecture;
using UnityEngine;
using Puzzle;

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
