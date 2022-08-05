using UnityEngine;

[System.Serializable]
public class PuzzleObject
{
    public GameObject tileGameObject;
    public Vector3Int spawnPosition;

    public PuzzleObject(GameObject tileGameObject, Vector3Int spawnPosition)
    {
        this.tileGameObject = tileGameObject;
        this.spawnPosition = spawnPosition;
    }
}
