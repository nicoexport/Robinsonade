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
      
      public Stance CurrentStance { get; private set; } = Stance.Regular;
      private bool _canMove = true;

      public void TryMoveTo(Direction targetDirection)
      {
         if (!_canMove)
            return;
         _canMove = false;
         float moveTime;
         Vector3 target = TileManager.Instance.GetNeighbourPosition(transform.position, targetDirection);

         bool collidingWithWall = TileManager.Instance.CheckCollision(target);
         if (collidingWithWall)
         {
            Collide(target);
            return;
         }
         
         if (CurrentStance == Stance.Regular)
         {
            UpdateFacingDirection(targetDirection);
            moveTime = _moveTimeInSecondsRegular;
         }
         else
         {
            moveTime = _moveTimeInSecondsPush;
         }
         UnregisterTileObject();
         Move(target, moveTime, FinishMove);
      }

      private void Move(Vector3 target, float moveTime, Action callback)
      {
         LeanTween.move(gameObject, target, moveTime).setOnComplete(callback);
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
         LeanTween.move(gameObject, transform.position + (Vector3)collisionVector * _collisionMovementInMeter,
            _collisionTimeInSeconds).setEasePunch().setOnComplete(() =>
         {
            _canMove = true;
         });
      }
      
      private void UpdateFacingDirection(Direction direction)
      {
         if (Equals(_facingDirection, direction))
            return;
         _facingDirection = direction;
      }

      public void SetStance(Stance stance)
      {
         if (Equals(CurrentStance, stance))
            return;
         CurrentStance = stance;
      }
   }
}
