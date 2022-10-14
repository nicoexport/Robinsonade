using Architecture;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Puzzle
{
   public class Spikes : DialogLevelReactive
   {
      [SerializeField] private Sprite _activeSprite;
      [SerializeField] private Sprite _inactiveSprite;
      
      private SpriteRenderer _renderer;
      private bool _registered;
      private bool _wantsRegister;
      

      public override void Initialize()
      {
         base.Initialize();
         _renderer = GetComponent<SpriteRenderer>();
         SetSprite(_activeSprite);
         _registered = true;
      }

      protected void FixedUpdate()
      {
         if (_wantsRegister)
         {
            TryRegister();
         }
      }

      protected override void UnderThresholdReaction()
      {
         _wantsRegister = true;
      }

      protected override void ThresholdReachedReaction()
      {
         if (!_registered)
            return;
         UnregisterTileObject();
         SetSprite(_inactiveSprite);
         _wantsRegister = false;
         _registered = false;
      }

      private void SetSprite(Sprite sprite)
      {
         if (_renderer == null)
            return;
         _renderer.sprite = sprite;
      }

      private void TryRegister()
      {
         if (_registered)
            return;
         if (TileManager.Instance.GetTileObjectAt(transform.position) != null)
            return;
         if (TileManager.Instance.CurrentPlayerMoveTarget == TileManager.Instance.WorldPosToGridPos(transform.position))
            return;
         RegisterTileObject(transform.position);
         SetSprite(_activeSprite);
         _registered = true;
         _wantsRegister = false;
      }
   }
}
