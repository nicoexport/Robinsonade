using UnityEngine;

namespace Architecture
{
    public abstract class TileObject : MonoBehaviour
    {
        public bool isSocketed;
        public Socket socket;

        public void Initialize()
        {
            TileManager.Instance.SnapToGrid(gameObject);
            RegisterTileObject();
        }

        public virtual void RegisterTileObjectInSocket(Socket socket)
        {
            if (socket)
            {
                isSocketed = true;
                this.socket = socket;
                socket.socketedTileObject = this;
            }
                TileManager.Instance.EvaluateSocketedTileObjects();
        }

        public virtual void UnRegisterTileObjectInSocket(Socket socket)
        {
            if (socket)
            {
                isSocketed = false;
                this.socket = null;
                socket.socketedTileObject = null;
            }
            TileManager.Instance.EvaluateSocketedTileObjects();
        }

        protected void RegisterTileObject()
        {
            TileManager.Instance.AddTileObject(this);
        }

        protected void RegisterTileObject(Vector3 position)
        {
            TileManager.Instance.AddTileObject(this, position);
        }

        protected void UnregisterTileObject()
        {
            TileManager.Instance.RemoveTileObject(this);
        }
    }
}
