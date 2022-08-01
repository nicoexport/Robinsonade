using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Architecture
{
   public class TileManager : Singleton<TileManager>
   {
      public Action OnTileObjectsUpdate;
      [SerializeField] private Tilemap[] _tilemaps;
      private readonly Dictionary<Vector3Int, TileObject> _tileObjects = new Dictionary<Vector3Int, TileObject>();

      public void AddTileObject(TileObject tileObject)
      {
         var pos = _tilemaps[0].WorldToCell(tileObject.transform.position);
         _tileObjects.Add(pos, tileObject);
      }

      public void AddTileObject(TileObject tileObject, Vector3 position)
      {
         var pos = _tilemaps[0].WorldToCell(position);
         _tileObjects.Add(pos, tileObject);
         //OnTileObjectsUpdate?.Invoke();
      }

      public void RemoveTileObject(TileObject tileObject)
      {
         var pos = _tilemaps[0].WorldToCell(tileObject.transform.position);
         _tileObjects.Remove(pos);
         //OnTileObjectsUpdate?.Invoke();
      }

      public TileObject GetTileObject(Vector3Int position)
      {
         if (!_tileObjects.ContainsKey(position))
            return null;
         return _tileObjects[position];
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

      public TileObject CheckForTileObject(Vector3 position)
      {
         var gridPos = _tilemaps[0].WorldToCell(position);
         if (_tileObjects.ContainsKey(gridPos))
            return _tileObjects[gridPos];
         return null;
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
      
      public Vector3Int GetNeighbour(Vector3 position, Direction direction)
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

         return neighbour;
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

