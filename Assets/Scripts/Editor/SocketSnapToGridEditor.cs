using Architecture;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[InitializeOnLoad]
[CanEditMultipleObjects]
[CustomEditor(typeof(Socket), true)]
public class SocketSnapToGridEditor : Editor
{
    private Socket socket;
    private Tilemap tilemap;

    private void OnEnable()
    {
        tilemap = GameObject.Find("Grid").transform.GetChild(0).GetComponent<Tilemap>();
    }

    private void OnSceneGUI()
    {
        socket = target as Socket;
        var pos = tilemap.WorldToCell(socket.transform.position);
        socket.transform.position = tilemap.GetCellCenterWorld(pos);
    }
}
