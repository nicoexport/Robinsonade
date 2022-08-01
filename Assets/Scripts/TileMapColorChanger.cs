using Architecture;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapColorChanger : MonoBehaviour
{
   [SerializeField] private Tilemap _tilemap;
   [SerializeField] private Color _color;

   public void ChangeColor()
   {
      _tilemap.color = _color;
   }
}