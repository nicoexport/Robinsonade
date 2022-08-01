using UnityEngine;

namespace Architecture
{
   public class Pushable : TileObject
   {
      [SerializeField] private bool _canPush = true;
      
      public bool Push(Direction direction, float timeInSeconds)
      {
         if (!_canPush)
            return false;
         var target = TileManager.Instance.GetNeighbourPosition(transform.position, direction);
         if(TileManager.Instance.CheckCollision(target))
            return false;

         var otherTileObj = TileManager.Instance.CheckForTileObject(target);
         if (otherTileObj != null)
         {
            if (otherTileObj is Pushable otherPushable)
            {
               if (!otherPushable.Push(direction, timeInSeconds))
               {
                  return false;
               }
            }
            else
            {
               return false;
            }
         }
         UnregisterTileObject();
         LeanTween.move(gameObject, target, timeInSeconds);
         RegisterTileObject(target);
         return true;
      }
   }
}
