using UnityEngine;

namespace Architecture
{
   public abstract class TileObject : MonoBehaviour
   {
      protected void Awake()
      {
         TileManager.Instance.SnapToGrid(gameObject);
         TileManager.Instance.AddTileObject(this);
      }
      
      protected void RegisterTileObject()
      {
         TileManager.Instance.AddTileObject(this);
      }

      protected void UnregisterTileObject()
      {
         TileManager.Instance.RemoveTileObject(this);
      }
   }
}
