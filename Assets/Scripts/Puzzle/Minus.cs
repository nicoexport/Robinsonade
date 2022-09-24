using Architecture;
using UnityEngine;

namespace Puzzle
{
   public class Minus : Operator
   {
      [SerializeField] private Direction _subtrahendDirection;
      
      public override int Evaluate()
      {
         GetNeighbourSymbols();

         int result = 0;
         int subtrahendIndex = (int) _subtrahendDirection;
         int minuendIndex = GetOpposingIndex(subtrahendIndex);

         if (_symbols[minuendIndex] == null || _symbols[subtrahendIndex] == null) return result;
         result += _symbols[minuendIndex].Impact;
         result -= _symbols[subtrahendIndex].Impact;
         return result;
      }
      
      private int GetOpposingIndex(int index)
      {
         int opposingIndex;
         if ((index + 2) > _symbols.Length)
         {
            opposingIndex = index - 2;
         }
         else
         {
            opposingIndex = index + 2;
         }
         return opposingIndex;
      }
   }
   
}
