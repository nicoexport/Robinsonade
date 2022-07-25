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
         if (TileManager.Instance.CheckCollision(_transform.position + (Vector3) direction))
         {
            // To do bounce against wall
            return;
         }
            
         _canMove = false;
         LeanTween.move(gameObject, _transform.position + (Vector3) direction, 0.3f).setOnComplete(() =>
         {
            _canMove = true;
         });
      }

      Vector2 GetDirection(Vector2 vector)
      {
         if (vector == Vector2.down || vector ==  Vector2.up || vector ==  Vector2.left || vector ==  Vector2.right)
            return vector; 
         if (vector.x >= 0.1f && Mathf.Abs(vector.y) >= 0.1f)
            return Vector2.right;
         if (vector.x <= -0.1f && Mathf.Abs(vector.y) >= 0.1f)
            return Vector2.left;
         return Vector2.zero;
      }
   }
}
