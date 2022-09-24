using System;
using System.Collections.Generic;
using Puzzle;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Architecture
{
    public class TileManager : Singleton<TileManager>
    {
        [SerializeField] private Tilemap[] _tilemaps;
        private readonly Dictionary<Vector3Int, Socket> _sockets = new Dictionary<Vector3Int, Socket>();
        private readonly Dictionary<Vector3Int, TileObject> _tileObjects = new Dictionary<Vector3Int, TileObject>();

        protected override void Awake()
        {
            base.Awake();

            var sockets = FindObjectsOfType<Socket>();
            foreach (var socket in sockets)
            {
                socket.Initialize();
            }

            var tileObjects = FindObjectsOfType<TileObject>();
            foreach (var tileObject in tileObjects)
            {
                tileObject.Initialize();
            }
        }

        public void AddSocket(Socket socket)
        {
            var pos = _tilemaps[0].WorldToCell(socket.transform.position);
            _sockets.Add(pos, socket);
        }

        public void AddSocket(Socket socket, Vector3 position)
        {
            var pos = _tilemaps[0].WorldToCell(position);
            _sockets.Add(pos, socket);
        }

        public void RemoveSocket(Socket socket)
        {
            var pos = _tilemaps[0].WorldToCell(socket.transform.position);
            _sockets.Remove(pos);
        }

        public void AddTileObject(TileObject tileObject)
        {
            var pos = _tilemaps[0].WorldToCell(tileObject.transform.position);
            _tileObjects.Add(pos, tileObject);
            if (_sockets.ContainsKey(pos))
                tileObject.RegisterTileObjectInSocket(_sockets[pos]);
        }

        public void AddTileObject(TileObject tileObject, Vector3 position)
        {
            var pos = _tilemaps[0].WorldToCell(position);
            _tileObjects.Add(pos, tileObject);
            if (_sockets.ContainsKey(pos))
                tileObject.RegisterTileObjectInSocket(_sockets[pos]);

        }

        public void RemoveTileObject(TileObject tileObject)
        {
            var pos = _tilemaps[0].WorldToCell(tileObject.transform.position);
            _tileObjects.Remove(pos);
            if (_sockets.ContainsKey(pos))
                tileObject.UnRegisterTileObjectInSocket(_sockets[pos]);
        }

        public bool CheckCollisionAt(Vector3 position)
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

        public TileObject GetTileObjectAt(Vector3 position)
        {
            var gridPos = _tilemaps[0].WorldToCell(position);
            if (_tileObjects.ContainsKey(gridPos))
                return _tileObjects[gridPos];
            return null;
        }

        public Socket GetSocketAt(Vector3 position)
        {
            var gridpos = _tilemaps[0].WorldToCell(position);
            if (_sockets.ContainsKey(gridpos))
                return _sockets[gridpos];
            return null;
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

        public Vector3 GetNeighbourPosition(Vector3 positionFrom, Direction direction)
        {
            Vector3Int neighbour = default;
            var playerTile = _tilemaps[0].WorldToCell(positionFrom);
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

        public void EvaluateSocketedTileObjects()
        {
            Debug.Log("evaluate");
            var operators = FindObjectsOfType<Operator>();
            int sum = 0;
            foreach (var op in operators)
            {
                sum += op.Evaluate();
            }
            DialogLevelManager.Instance.SetDialogLevel(sum);
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

