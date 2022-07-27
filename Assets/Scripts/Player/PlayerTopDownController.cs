using System;
using Architecture;
using UnityEngine;

namespace Player
{
   public class PlayerTopDownController : MonoBehaviour
   {
      Vector2 _moveVector;
      bool _wantMove;
      bool _canMove = true;
      Transform _transform;
      ITopDownCharacter _character;
      Vector2 _prevVector;

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

      Vector2 GetMoveVector()
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

      protected void FixedUpdate()
      {
         Move();
      }

      // ReSharper disable Unity.PerformanceAnalysis
      void Move()
      {
         var moveVector = _moveVector;
         if (moveVector.magnitude == 0)
            return;
         if (!_canMove)
            return;

         var direction = GetDirection(moveVector);
         var target = TileManager.Instance.GetNeighbourPosition(_transform.position, direction);
         
         if (TileManager.Instance.CheckCollision(target))
         {
            _canMove = false;
            _character.Collide(GetVector2FromDirection(direction), () => { _canMove = true;});
            return;
         }
         _canMove = false;
         _character.Move(target, GetVector2FromDirection(direction), () => { _canMove = true; } );
      }

      Direction GetDirection(Vector2 vector)
      {
         if (vector == Vector2.down)
            return Direction.South;
         if (vector == Vector2.up)
            return Direction.North;
         if(vector ==  Vector2.left)
            return Direction.West;
         if(vector ==  Vector2.right)
            return Direction.East; 
         
         if (vector.x >= 0.1f && Mathf.Abs(vector.y) >= 0.1f)
            return Direction.East;
         if (vector.x <= -0.1f && Mathf.Abs(vector.y) >= 0.1f)
            return Direction.West;
         return Direction.None;
      }

      static Vector2 GetVector2FromDirection(Direction direction)
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
