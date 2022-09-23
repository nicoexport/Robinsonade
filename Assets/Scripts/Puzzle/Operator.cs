using System;
using Architecture;
using UnityEngine;

namespace Puzzle
{
   public abstract class Operator : MonoBehaviour
   {
      protected Symbol[] _symbols = new Symbol[4];
      
      public virtual int Evaluate()
      {
         return 0;
      }

      protected void GetNeighbourSymbols()
      {
         Direction[] directions = (Direction[]) Enum.GetValues(typeof(Direction));
         for (int i = 0; i < directions.Length - 1; i++)
         {
            var neighbourPosition = TileManager.Instance.GetNeighbourPosition(transform.position, directions[i]);
            var neighbor = TileManager.Instance.GetTileObjectAt(neighbourPosition);
            if (neighbor && neighbor.TryGetComponent(out Symbol symbol))
            {
               _symbols[i] = symbol;
            }
            else
            {
               _symbols[i] = null;
            }
         }
      }
   }
}

