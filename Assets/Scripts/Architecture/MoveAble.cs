using UnityEngine;

namespace Architecture
{
    public class MoveAble : TileObject
    {
        public bool isSocketed;
        public Socket socket;

        public override void RegisterTileObjectInSocket(Socket socket)
        {
            if (socket)
            {
                isSocketed = true;
                this.socket = socket;
                socket.socketedTileObject = this;
                if (socket.socketType == SocketType.Locked)
                {
                    socket.LockSocket();
                }
            }
            TileManager.Instance.EvaluateSocketedTileObjects();
        }

        public override void UnRegisterTileObjectInSocket(Socket socket)
        {
            if (socket)
            {
                isSocketed = false;
                this.socket = null;
                socket.socketedTileObject = null;
            }
            TileManager.Instance.EvaluateSocketedTileObjects();
        }

        public bool Move(Direction direction, float timeInSeconds, int depth)
        {
            if (IsLocked())
                return false;
            if (depth <= 0)
                return false;
            depth = depth - 1;
            var target = TileManager.Instance.GetNeighbourPosition(transform.position, direction);
            if (TileManager.Instance.CheckCollisionAt(target))
                return false;

            var otherTileObj = TileManager.Instance.GetTileObjectAt(target);
            if (otherTileObj != null)
            {
                if (otherTileObj is MoveAble otherPushable)
                {
                    if (!otherPushable.Move(direction, timeInSeconds, depth))
                    {
                        return false;
                    }
                }
            }

            var neighbourSocket = TileManager.Instance.GetSocketAt(target);
            if (neighbourSocket != null)
            {
                if (!neighbourSocket.canBePushedOnto)
                {
                    return false;
                }
            }

            UnregisterTileObject();
            LeanTween.move(gameObject, target, timeInSeconds);
            RegisterTileObject(target);
            return true;
        }

        public bool IsLocked()
        {
            if (socket && socket.isLocked)
            {
                return true;
            }
            return false;
        }
    }
}
