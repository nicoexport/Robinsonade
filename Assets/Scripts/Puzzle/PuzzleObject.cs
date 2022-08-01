using UnityEngine;
using Architecture;

[System.Serializable]
public class PuzzleObject
{
    public TileObject tileObject;
    public Vector3Int spawnPosition;

    public PuzzleObject(TileObject tileObject, Vector3Int spawnPosition)
    {
        this.tileObject = tileObject;
        this.spawnPosition = spawnPosition;
    }
}
