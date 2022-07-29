using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Architecture
{
   public class TileManager : Singleton<TileManager>
   {
      [SerializeField] Tilemap[] _tilemaps;
      private readonly Dictionary<Vector3Int, TileObject> _tileObjects = new Dictionary<Vector3Int, TileObject>();

      public void AddTileObject(TileObject tileObject)
      {
         var pos = _tilemaps[0].WorldToCell(tileObject.transform.position);
         _tileObjects.Add(pos, tileObject);
         foreach (var obj in _tileObjects)
         {
            Debug.Log(obj.Key);
         }
      }

      public void RemoveTileObject(TileObject tileObject)
      {
         var pos = _tilemaps[0].WorldToCell(tileObject.transform.position);
         _tileObjects.Remove(pos);
      }
      
      public void SnapToGrid(GameObject obj)
      {
         var pos = _tilemaps[0].WorldToCell(obj.transform.position);
         obj.transform.position = _tilemaps[0].GetCellCenterWorld(pos);
      }

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
         Vector3Int neighbour = default;
         var playerTile = _tilemaps[0].WorldToCell(position);
         switch (direction)
         {
            case Direction.North:
               neighbour = playerTile + Vector3Int.up;
               break;
            case Direction.West:
               neighbour = playerTile + Vector3Int.left;
               break;
            case Direction.South:
               neighbour = playerTile + Vector3Int.down;
               break;
            case Direction.East:
               neighbour = playerTile + Vector3Int.right;
               break;
            case Direction.None:
               neighbour = playerTile;
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
         }
         return _tilemaps[0].GetCellCenterWorld(neighbour);
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
}

