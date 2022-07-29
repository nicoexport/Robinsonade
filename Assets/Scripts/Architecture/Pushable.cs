using UnityEngine;

namespace Architecture
{
   public class Pushable : TileObject
   {
      public void Push(Direction direction)
      {
         Debug.Log("Push" + direction);
         var target = TileManager.Instance.GetNeighbourPosition(transform.position, direction);
         if (TileManager.Instance.CheckForTileObject(target) != null || TileManager.Instance.CheckCollision(target))
            return;
         UnregisterTileObject();
         transform.position = target;
         RegisterTileObject();
      }
   }
}
