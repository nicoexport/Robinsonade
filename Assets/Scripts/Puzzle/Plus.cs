using UnityEngine;

namespace Puzzle
{
   public class Plus : Operator
   {
      public override int Evaluate()
      {
         GetNeighbourSymbols();

         int sum = 0;
         if (_symbols[0] != null && _symbols[2] != null)
            sum += ((int) _symbols[0].SymbolData.Impact - 1) + ((int) _symbols[2].SymbolData.Impact - 1);
         if (_symbols[1] != null && _symbols[3] != null)
            sum += ((int) _symbols[1].SymbolData.Impact - 1) + ((int) _symbols[3].SymbolData.Impact - 1);
         return sum;
      }
   }
}
