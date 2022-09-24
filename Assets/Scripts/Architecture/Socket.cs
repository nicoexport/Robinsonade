using UnityEngine;

namespace Architecture
{
    public class Socket : MonoBehaviour
    {
        public SocketType socketType;

        [HideInInspector] public TileObject socketedTileObject;
        [HideInInspector] public bool canBePushedOnto = true;
        [HideInInspector] public bool isLocked = false;

        private void OnValidate()
        {
            switch (socketType)
            {
                case SocketType.Loose:
                    canBePushedOnto = true;
                    isLocked = false;
                    break;
                case SocketType.Locked:
                    canBePushedOnto = true;
                    isLocked = false;
                    break;
                case SocketType.DialogLocked:
                    canBePushedOnto = true;
                    isLocked = true;
                    break;
                case SocketType.Identity:
                    canBePushedOnto = false;
                    isLocked = false;
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
            isLocked = false;
        }

        public void LockSocket()
        {
            canBePushedOnto = false;
            isLocked = true;
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