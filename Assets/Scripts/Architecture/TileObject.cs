using UnityEngine;

namespace Architecture
{
    public abstract class TileObject : MonoBehaviour
    {
        protected bool shouldInitialize = true;
        public virtual void Initialize()
        {
            TileManager.Instance.SnapToGrid(gameObject);
            RegisterTileObject();
        }

        public virtual void RegisterTileObjectInSocket(Socket socket)
        {

        }

        public virtual void UnRegisterTileObjectInSocket(Socket socket)
        {

        }

        public void RegisterTileObject()
        {
            TileManager.Instance.AddTileObject(this);
        }

        public void RegisterTileObject(Vector3 position)
        {
            TileManager.Instance.AddTileObject(this, position);
        }

        public void UnregisterTileObject()
        {
            TileManager.Instance.RemoveTileObject(this);
        }
    }
}
