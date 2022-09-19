using UnityEngine;

namespace Architecture
{
    public class Socket : MonoBehaviour
    {
        public SocketType socketType;

        [HideInInspector] public TileObject socketedTileObject;
        [HideInInspector] public bool canBePushedOnto = true;

        private void OnValidate()
        {
            switch (socketType)
            {
                case SocketType.Loose:
                    canBePushedOnto = true;
                    break;
                case SocketType.Locked:
                    canBePushedOnto = true;
                    break;
                case SocketType.DialogLocked:
                    canBePushedOnto = false;
                    break;
                case SocketType.Identity:
                    canBePushedOnto = false;
                    break;
                default:
                    break;
            }
        }

        public void Initialize()
        {
            TileManager.Instance.SnapToGrid(gameObject);
            RegisterSocket();
        }

        public void UnlockSocket()
        {
            canBePushedOnto = true;
        }

        public void LockSocket()
        {
            canBePushedOnto = false;
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