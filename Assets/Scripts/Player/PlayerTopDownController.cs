using System;
using Architecture;
using UnityEngine;

namespace Player
{
   public class PlayerTopDownController : MonoBehaviour
   {
      [SerializeField] private float _moveTimeInSeconds = 0.2f;
      [SerializeField] private float _pushTimeInSeconds = 0.3f;
      [SerializeField] private float _collideTimeInSeconds = 0.2f;
      private Vector2 _moveVector;
      private bool _wantMove;
      private bool _canMove = true;
      private Transform _transform;
      private ITopDownCharacter _character;
      private Vector2 _prevVector;

      protected void Awake()
      {
         _transform = transform;
         _character = GetComponent<ITopDownCharacter>();
      }
      
      protected void OnEnable()
      {
         InputManager.Instance.ToggleActionMap(InputManager.Instance.PlayerInputActions.Topdown);
      }
      
      protected void Update()
      {
         _moveVector = GetMoveVector();
      }
      
      protected void FixedUpdate()
      {
         HandleInput();
      }

      // ReSharper disable Unity.PerformanceAnalysis
      private void HandleInput()
      {
         if (!_canMove)
            return;
         var moveVector = _moveVector;
         if (moveVector.magnitude == 0)
            return;
         
         var direction = GetDirection(moveVector);
         var target = TileManager.Instance.GetNeighbourPosition(_transform.position, direction);
         var tileObj = TileManager.Instance.CheckForTileObject(target);
         
         if (tileObj != null)
         {
            if (CheckTileObjectCollision(tileObj, direction, target)) return;
         }
         CheckTilemapCollision(target, direction);
      }

      private bool CheckTileObjectCollision(TileObject tileObj, Direction direction, Vector3 target)
      {
         if (tileObj is MoveAble pushable)
         {
            if (!pushable.Move(direction, _pushTimeInSeconds))
            {
               Collide(direction);
               return true;
            }
            Move(target, direction, _pushTimeInSeconds);
            return true;
         }
         return false;
      }
      
      private void CheckTilemapCollision(Vector3 target, Direction direction)
      {
         if (TileManager.Instance.CheckCollision(target))
         {
            Collide(direction);
            return;
         }
         Move(target, direction, _moveTimeInSeconds);
      }

      private void Move(Vector3 target, Direction direction, float timeInSeconds)
      {
         _canMove = false;
         _character.Move(target, GetVector2FromDirection(direction), timeInSeconds, () => { _canMove = true; });
      }

      private void Collide(Direction direction)
      {
         _canMove = false;
         _character.Collide(GetVector2FromDirection(direction), _collideTimeInSeconds, () => { _canMove = true; });
      }

      private Vector2 GetMoveVector()
      {
         var vector = InputManager.Instance.PlayerInputActions.Topdown.Move.ReadValue<Vector2>();
         if (vector == Vector2.zero)
            return vector;
         if (vector == Vector2.up || vector == Vector2.down || vector == Vector2.right || vector == Vector2.left)
         {
            _prevVector = vector;
            return vector;
         }
         return vector - _prevVector;
      }

      private Direction GetDirection(Vector2 vector)
      {
         if (vector == Vector2.down)
            return Direction.South;
         if (vector == Vector2.up)
            return Direction.North;
         if(vector ==  Vector2.left)
            return Direction.West;
         if(vector ==  Vector2.right)
            return Direction.East;
         
         return Direction.None;
      }

      private static Vector2 GetVector2FromDirection(Direction direction)
      {
         Vector3 vector;
         switch (direction)
         {
            case Direction.North:
               vector = Vector3.up;
               break;
            case Direction.West:
               vector = Vector3.left;
               break;
            case Direction.South:
               vector = Vector3.down;
               break;
            case Direction.East:
               vector = Vector3.right;
               break;
            case Direction.None:
               vector = Vector3.zero;
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
         }
         return vector;
      }
   }
}
