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

      protected void Awake()
      {
         _transform = transform;   
      }
      
      protected void OnEnable()
      {
         InputManager.Instance.ToggleActionMap(InputManager.Instance.PlayerInputActions.Topdown);
      }
      
      protected void Update()
      {
         _moveVector = InputManager.Instance.PlayerInputActions.Topdown.Move.ReadValue<Vector2>();
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
            // To do bounce against wall
            return;
         }
            
         _canMove = false;
         LeanTween.move(gameObject, target, 0.3f).setOnComplete(() =>
         {
            _canMove = true;
         });
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
   }
}
