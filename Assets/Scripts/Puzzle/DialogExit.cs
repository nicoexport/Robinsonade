using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Puzzle;

public class DialogExit : PuzzleRoomExit
{
    [SerializeField]
    private int _sceneToLoadIndex;

    public override void Exit()
    {
        SceneLoader.Instance.LoadScene(_sceneToLoadIndex);
    }
}
