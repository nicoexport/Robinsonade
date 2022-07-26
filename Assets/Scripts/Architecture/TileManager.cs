using System;
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

      public Vector3 GetNeighbourPosition(Vector3 position, Direction direction)
      {
         Vector3 neighbour = default;
         var playerTile = _tilemaps[0].WorldToCell(position);
         TileBase targetTile = default;
         switch (direction)
         {
            case Direction.North:
              
               break;
            case Direction.West:
               break;
            case Direction.South:
               break;
            case Direction.East:
               break;
            case Direction.None:
               return position;
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
         }
         return neighbour;
      }
   }
}

public enum Direction
{
   North, 
   West, 
   South,
   East,
   None
}
