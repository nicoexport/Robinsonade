using UnityEngine;

namespace Puzzle
{
   public class Relation : Operator
   {
      [SerializeField] private Sprite[] _sprites;
      private SpriteRenderer _renderer;

      private void Awake()
      {
         _renderer = GetComponent<SpriteRenderer>();
      }

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

         UpdateVisuals();
         return result;
      }

      private void UpdateVisuals()
      {  
         Debug.Log("Update Visuals");
         if (_symbols[1] != null && _symbols[3] != null)
         {
            if (_symbols[1].Impact > _symbols[3].Impact)
            {
               _renderer.sprite = _sprites[(int) RelationType.Greater];
            }
            else if (_symbols[1].Impact == _symbols [3].Impact)
            {
               _renderer.sprite = _sprites[(int) RelationType.Equals];
            }
            else
            {
               _renderer.sprite = _sprites[(int) RelationType.Less];
            }
         }
         else
         {
            if (_symbols[1] != null)
            {
               _renderer.sprite = _sprites[(int) RelationType.Greater];
            }

            if (_symbols[3] != null)
            {
               _renderer.sprite = _sprites[(int) RelationType.Less];
            }
         }
      }
   }
}
