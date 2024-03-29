using UnityEngine;

namespace Puzzle
{
   [CreateAssetMenu(fileName = "New NPC", menuName = "Scriptable Objects/Npc", order = 0)]
   public class NpcSo : ScriptableObject
   {
      [Header("Facts")]
      [Space(10)]
      public string Name;
      
      [SerializeField]
      private int _age;
      public int Age
      {
       get => _age;
       set => _age = (int)Mathf.Clamp(value, 0, Mathf.Infinity);
      }
      public ProfessionSo Profession;
      
      [Header("Personality")]
      [Space(10)]
      public PrimaryPersonalityTrait PrimaryPersonalityTrait;
      public SecondaryPersonalityTrait SecondaryPersonalityTrait;
      public TertiaryPersonalityTrait TertiaryPersonalityTrait;
      [Space(10)]
      public SymbolCategory[] affections = new SymbolCategory[3];
      public int[] affectionWeights = new int[3];
      
      [Space(10)]
      public SymbolCategory[] antipathies = new SymbolCategory[3];
      public int[] antipathyWeights = new int[3];

      [Header("Relationship")] 
      [Space(10)] 
      [SerializeField]
      private float _relationshipLevel;
      public float RelationshipLevel
      {
         get => _relationshipLevel;
         set => _relationshipLevel = Mathf.Clamp(value, 0f, 100f);
      }
      
      private void OnValidate()
      {
         Age = _age;
         RelationshipLevel = _relationshipLevel;
      }
   }
}
