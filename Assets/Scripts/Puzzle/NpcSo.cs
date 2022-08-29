using System;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
   [CreateAssetMenu(fileName = "New NPC", menuName = "Scriptable Objects/Npc", order = 0)]
   public class NpcSo : ScriptableObject
   {
      public string Name;
      
      [SerializeField]
      private int _age;
      public int Age
      {
       get => _age;
       set => _age = (int)Mathf.Clamp(value, 0, Mathf.Infinity);
      }

      public PrimaryPersonalityTrait PrimaryPersonalityTrait;
      public SecondaryPersonalityTrait SecondaryPersonalityTrait;
      public TertiaryPersonalityTrait TertiaryPersonalityTrait;
      
      private void OnValidate()
      {
         Age = _age;
      }
   }
}
