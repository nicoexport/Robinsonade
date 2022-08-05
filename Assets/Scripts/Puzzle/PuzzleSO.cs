using System.Collections.Generic;
using UnityEngine;
using Architecture;

[CreateAssetMenu(fileName = "SO_Puzzle", menuName = "Scriptable Objects/Puzzle", order = 0)]
public class PuzzleSO : ScriptableObject
{
    public Vector3Int playerSpawnPosition;
    public Vector3Int[] wallTilePositions;
    public RuleTile wallTile;
    public PuzzleObject[] puzzleObjects;
}
