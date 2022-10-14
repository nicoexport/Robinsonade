using System;
using Architecture;
using UnityEngine;
using UnityEngine.Events;

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
      [SerializeField] private bool _canPushSideways;
      [SerializeField] private bool _needsPushTarget;

      public UnityEvent OnCollision;
      public UnityEvent OnMove;

      private Stance _currentStance = Stance.Regular;
      private bool _canMove = true;

      private readonly Vector3[] VectorFromDirection = 
         new [] {Vector3.up, Vector3.left, Vector3.down, Vector3.right, Vector3.zero};

      public override void Initialize()
      {
         base.Initialize();
         //PuzzleRoomManager.Instance.Player = this.transform;
      }

      public void TryMoveTo(Direction targetDirection)
      {
         if (!_canMove)
            return;
         if (!ValidateMoveDirection(targetDirection))
            return;
         _canMove = false;
         UnregisterTileObject();
         Vector3 moveTarget = TileManager.Instance.GetNeighbourPosition(transform.position, targetDirection);
         TileManager.Instance.CurrentPlayerMoveTarget = TileManager.Instance.WorldPosToGridPos(moveTarget);
         bool moveTargetIsWall = TileManager.Instance.CheckCollisionAt(moveTarget);
         var tileObjectAtMoveTarget = TileManager.Instance.GetTileObjectAt(moveTarget);
         
         if (tileObjectAtMoveTarget is PuzzleRoomExit exit)
         {
            exit.Exit();
            _canMove = true;
            return;
         }
         
         if (_currentStance == Stance.Regular)
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

         if (_currentStance == Stance.Pushing)
         {
            Vector3 facingTarget = transform.position + VectorFromDirection[(int) _facingDirection];
            var facingTileObject = TileManager.Instance.GetTileObjectAt(facingTarget);
            
            if (moveTargetIsWall || (tileObjectAtMoveTarget) && (tileObjectAtMoveTarget != facingTileObject) || 
                (facingTileObject is not MoveAble && facingTileObject != null))
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
         OnMove?.Invoke();
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
         OnCollision.Invoke();
         
      }
      
      private void UpdateFacingDirection(Direction direction)
      {
         if (Equals(_facingDirection, direction))
            return;
         _facingDirection = direction;
         if ((int) direction >= _directionSprites.Length)
            return;
         _directionRenderer.sprite = _directionSprites[(int)direction];
      }

      private bool ValidateMoveDirection(Direction targetDirection)
      {
         if (_currentStance == Stance.Regular)
            return true;

         if (_canPushSideways)
            return true;
         
         switch (_facingDirection)
         {
            case Direction.North:
               if (targetDirection != Direction.North && targetDirection != Direction.South)
                  return false;
               break;
            case Direction.West:
               if (targetDirection != Direction.West && targetDirection != Direction.East)
                  return false;
               break;
            case Direction.South:
               if (targetDirection != Direction.North && targetDirection != Direction.South)
                  return false;
               break;
            case Direction.East:
               if (targetDirection != Direction.West && targetDirection != Direction.East)
                  return false;
               break;
            case Direction.None:
               return false;
            default:
               return false;
         }
         return true;
      }

      public void SetStance(Stance stance)
      {
         if (Equals(_currentStance, stance))
            return;
         
         if (_needsPushTarget && stance == Stance.Pushing)
         {
            Vector3 targetPosition = TileManager.Instance.GetNeighbourPosition(transform.position, _facingDirection);
            var targetObject = TileManager.Instance.GetTileObjectAt(targetPosition);
            if(!targetObject)
               return;
         }
         _currentStance = stance;
      }
   }
}
