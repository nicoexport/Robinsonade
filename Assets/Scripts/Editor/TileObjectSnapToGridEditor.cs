using Architecture;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[InitializeOnLoad]
[CanEditMultipleObjects]
[CustomEditor(typeof(TileObject), true)]
public class SnapToGridEditor : Editor
{
    private TileObject tileObject;
    private Tilemap tilemap;

    private void OnEnable()
    {
        tilemap = GameObject.Find("Grid").transform.GetChild(0).GetComponent<Tilemap>();
    }

    private void OnSceneGUI()
    {
        tileObject = target as TileObject;

        var pos = tilemap.WorldToCell(tileObject.transform.position);
        tileObject.transform.position = tilemap.GetCellCenterWorld(pos);
    }
}
