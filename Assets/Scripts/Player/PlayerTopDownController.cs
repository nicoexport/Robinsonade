using System;
using Architecture;
using UnityEngine;

namespace Player
{
   public class PlayerTopDownController : MonoBehaviour
   {
      [SerializeField] private float _moveTimeInSeconds = 0.2f;
      [SerializeField] private float _pushTimeInSeconds = 0.3f; 
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

         var tileObj = TileManager.Instance.CheckForTileObject(target);
         if (tileObj != null)
         {
            if (tileObj is Pushable pushable)
            {
               if (!pushable.Push(direction, _pushTimeInSeconds))
               {
                  _canMove = false;
                  _character.Collide(GetVector2FromDirection(direction), () => { _canMove = true;});
                  return;
               }
               _canMove = false;
               _character.Move(target, GetVector2FromDirection(direction), _pushTimeInSeconds,() => { _canMove = true;});
               return;
            }
         }
         
         if (TileManager.Instance.CheckCollision(target))
         {
            _canMove = false;
            _character.Collide(GetVector2FromDirection(direction), () => { _canMove = true;});
            return;
         }
         _canMove = false;
         _character.Move(target, GetVector2FromDirection(direction), _moveTimeInSeconds, () => { _canMove = true; } );
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
