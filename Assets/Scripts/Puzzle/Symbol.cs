using System;
using UnityEngine;

namespace Puzzle
{
   public class Symbol : MonoBehaviour
   {
      [SerializeField] 
      private Sprite _defaultSprite;
      [field: SerializeField]
      public SymbolData SymbolData { get; private set; } = default;
      private SpriteRenderer _renderer = default;


      private void Awake()
      {
         GetRenderer();
         SetSprite();
      }

      private void GetRenderer()
      {
         if (_renderer) return;
         if (TryGetComponent(out SpriteRenderer rend))
         {
            _renderer = rend;
         }
      }


#if UNITY_EDITOR
      private void OnValidate()
      {
         if (!_renderer)
         {
            if (TryGetComponent(out SpriteRenderer rend))
            {
               _renderer = rend;
            }
            return;
         }
         UnityEditor.EditorApplication.delayCall += OnValidateCallback;
      }

      private void OnValidateCallback()
      {
         if (this == null)
         {
            UnityEditor.EditorApplication.delayCall -= OnValidateCallback;
            return; // MissingRefException if managed in the editor - uses the overloaded Unity == operator.
         }
         SetSprite();
      }
#endif

      private void SetSprite()
      {
         if (!SymbolData)
         {
            _renderer.sprite = _defaultSprite;
         }
         else
         {
            if (!SymbolData.Sprite)
            {
               Debug.LogWarning("No Sprite in Symbol Data at: " + gameObject.name);
               _renderer.sprite = _defaultSprite;
            }
            else
            {
               _renderer.sprite = SymbolData.Sprite;
            }
         }
      }
   }
}
