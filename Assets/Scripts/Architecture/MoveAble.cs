using UnityEngine;

namespace Architecture
{
   public class MoveAble : TileObject
   {
      public bool Move(Direction direction, float timeInSeconds, int depth)
      {
         if (depth <= 0)
            return false;
         depth = depth - 1;
         var target = TileManager.Instance.GetNeighbourPosition(transform.position, direction);
         if(TileManager.Instance.CheckCollisionAt(target))
            return false;

         var otherTileObj = TileManager.Instance.GetTileObjectAt(target);
         if (otherTileObj != null)
         {
            if (otherTileObj is MoveAble otherPushable)
            {
               if (!otherPushable.Move(direction, timeInSeconds, depth))
               {
                  return false;
               }
            }
         }
         
         UnregisterTileObject();
         LeanTween.move(gameObject, target, timeInSeconds);
         RegisterTileObject(target);
         return true;
      }
   }
}
