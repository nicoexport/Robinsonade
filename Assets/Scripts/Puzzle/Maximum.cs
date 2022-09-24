namespace Puzzle
{
   public class Maximum : Operator
   {
      public override int Evaluate()
      {
         int result = int.MinValue;
         GetNeighbourSymbols();
         foreach (Symbol symbol in _symbols)
         {
            if (symbol == null) continue;
            if (symbol.Impact > result)
               result = symbol.Impact;
         }

         if (result == int.MinValue)
            result = 0;
         
         return result;
      }
   }
}
