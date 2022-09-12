using UnityEngine;

namespace Architecture
{
    public class Socket : MonoBehaviour
    {
        public SocketType socketType;

        public void Initialize()
        {
            TileManager.Instance.SnapToGrid(gameObject);
            RegisterSocket();
        }

        protected void RegisterSocket()
        {
            TileManager.Instance.AddSocket(this);
        }

        protected void RegisterSocket(Vector3 position)
        {
            TileManager.Instance.AddSocket(this, position);
        }

        protected void UnregisterSocket()
        {
            TileManager.Instance.RemoveSocket(this);
        }
    }
}