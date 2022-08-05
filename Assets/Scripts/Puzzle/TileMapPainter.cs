using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapPainter : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tileMap;

    public void PaintTile(Vector3Int position, RuleTile tileToPaint)
    {
        _tileMap.SetTile(position, tileToPaint);
    }
}
