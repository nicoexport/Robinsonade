using UnityEngine;

namespace Architecture
{
   public abstract class TileObject : MonoBehaviour
   {
      protected virtual void Awake()
      {
         TileManager.Instance.SnapToGrid(gameObject);
         RegisterTileObject();
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

      public void Delete()
      {
         UnregisterTileObject();
         Destroy(gameObject);
      }
   }
}