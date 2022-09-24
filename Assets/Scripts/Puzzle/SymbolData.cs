using UnityEngine;

namespace Puzzle
{
   [CreateAssetMenu(fileName = "New Symbol Data", menuName = "Scriptable Objects/Symbol Data", order = 0)]
   public class SymbolData : ScriptableObject
   {
      [field: SerializeField]
      public SymbolValue Impact { get; private set; } = default;
      [field: SerializeField]
      public Sprite Sprite { get; private set; } = default;
   }
}
