using UnityEngine;

namespace Puzzle
{
   public class Plus : Operator
   {
      public override int Evaluate()
      {
         GetNeighbourSymbols();

         int result = 0;
         if (_symbols[0] != null && _symbols[2] != null)
            result +=  _symbols[0].Impact +  _symbols[2].Impact;
         if (_symbols[1] != null && _symbols[3] != null)
            result += _symbols[1].Impact + _symbols[3].Impact;
         return result;
      }
   }
}
