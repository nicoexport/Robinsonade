using System;
using Architecture;
using UnityEngine;

namespace Puzzle
{
   public class TopDownCharacter : TileObject 
   {
      public enum Stance
      {
         Regular,
         Pushing
      }

      [SerializeField] private Direction _facingDirection;
      [SerializeField] private float _moveTimeInSecondsRegular;
      [SerializeField] private float _moveTimeInSecondsPush;
      [SerializeField] private float _moveRotation;
      [SerializeField] private AnimationCurve _moveRotationCurve;
      [SerializeField] private float _collisionMovementInMeter;
      [SerializeField] private float _collisionTimeInSeconds;
      [SerializeField] private int _pushDepth = 1;
      [SerializeField] private SpriteRenderer _directionRenderer;
      [SerializeField] private Sprite[] _directionSprites;
      
      public Stance CurrentStance { get; private set; } = Stance.Regular;
      private bool _canMove = true;

      private readonly Vector3[] VectorFromDirection =
         new[] {Vector3.up, Vector3.left, Vector3.down, Vector3.right, Vector3.zero};

      public void TryMoveTo(Direction targetDirection)
      {
         if (!_canMove)
            return;
         _canMove = false;
         UnregisterTileObject();
         Vector3 moveTarget = TileManager.Instance.GetNeighbourPosition(transform.position, targetDirection);
         bool moveTargetIsWall = TileManager.Instance.CheckCollisionAt(moveTarget);
         var tileObjectAtMoveTarget = TileManager.Instance.GetTileObjectAt(moveTarget);
         
         if (CurrentStance == Stance.Regular)
         {
            UpdateFacingDirection(targetDirection);
            
            if (moveTargetIsWall || tileObjectAtMoveTarget)
            {
               Collide(moveTarget);
               return;
            }
            
            Move(moveTarget, _moveTimeInSecondsRegular);
            return;
         }

         if (CurrentStance == Stance.Pushing)
         {
            Vector3 facingTarget = transform.position + VectorFromDirection[(int) _facingDirection];
            var facingTileObject = TileManager.Instance.GetTileObjectAt(facingTarget);
            
            if (moveTargetIsWall || (tileObjectAtMoveTarget) && (tileObjectAtMoveTarget != facingTileObject))
            {
               Collide(moveTarget);
               return;
            }
            
            if (facingTileObject is MoveAble moveAble)
            {
               if (!moveAble.Move(targetDirection, _moveTimeInSecondsPush, _pushDepth))
               {
                  Collide(moveTarget);
                  return;
               }
            }
            Move(moveTarget, _moveTimeInSecondsPush);
         }
      }

      private void Move(Vector3 target, float moveTime)
      {
         LeanTween.move(gameObject, target, moveTime).setOnComplete(FinishMove);
         LeanTween.rotateZ(gameObject, _moveRotation, moveTime).setEase(_moveRotationCurve);
      }

      private void FinishMove()
      {
         RegisterTileObject();
         _canMove = true;
      }

      private void Collide(Vector3 target)
      {
         Vector3 collisionVector = target - transform.position;
         LeanTween.move(gameObject, transform.position + (Vector3) collisionVector * _collisionMovementInMeter,
            _collisionTimeInSeconds).setEasePunch().setOnComplete(FinishMove);
      }
      
      private void UpdateFacingDirection(Direction direction)
      {
         if (Equals(_facingDirection, direction))
            return;
         _facingDirection = direction;
         if ((int) direction > _directionSprites.Length)
            return;
         _directionRenderer.sprite = _directionSprites[(int)direction];
      }

      public void SetStance(Stance stance)
      {
         if (Equals(CurrentStance, stance))
            return;
         CurrentStance = stance;
      }
   }
}
