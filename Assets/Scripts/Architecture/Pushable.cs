using UnityEngine;

namespace Architecture
{
   public class Pushable : TileObject
   {
      public bool Push(Direction direction)
      {
         Debug.Log("Push" + direction);
         var target = TileManager.Instance.GetNeighbourPosition(transform.position, direction);
         if(TileManager.Instance.CheckCollision(target))
            return false;

         var otherTileObj = TileManager.Instance.CheckForTileObject(target);
         if (otherTileObj != null)
         {
            if (otherTileObj is Pushable otherPushable)
            {
               if (!otherPushable.Push(direction))
               {
                  return false;
               }
            }
         }
         UnregisterTileObject();
         transform.position = target;
         RegisterTileObject();
         return true;
      }
   }
}
