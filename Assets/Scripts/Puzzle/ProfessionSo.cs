using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
   [CreateAssetMenu(fileName = "new Profession", menuName = "Scriptable Objects/Profession", order = 0)]
   public class ProfessionSo : ScriptableObject
   {
      public string Name;
      public List<SymbolCategory> Affections = new List<SymbolCategory>();
   }
}
