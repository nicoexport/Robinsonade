using UnityEngine;
using UnityEngine.Tilemaps;

namespace Architecture
{
   public class TileManager : Singleton<TileManager>
   {
      [SerializeField] Tilemap[] _tilemaps;

      public bool CheckCollision(Vector3 position)
      {
         foreach (var map in _tilemaps)
         {
            var gridPosition = map.WorldToCell(position);
            if (!map.HasTile(gridPosition)) continue;
            var colType = map.GetColliderType(gridPosition);
            if (colType != Tile.ColliderType.None)
               return true;
         }
         return false;
      }
   }
}
