using UnityEngine;

namespace Architecture
{
    public abstract class TileObject : MonoBehaviour
    {
        public void Initialize()
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
