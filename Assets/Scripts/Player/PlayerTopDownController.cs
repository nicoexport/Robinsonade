using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
   public class PlayerTopDownController : MonoBehaviour
   {
      Vector3 _moveVector;
      bool _wantMove;
      bool _canMove = true;
      
      protected void OnEnable()
      {
         InputManager.Instance.ToggleActionMap(InputManager.Instance.PlayerInputActions.Topdown);
         InputManager.Instance.TopDownMoveEvent += ReadMoveValue;
      }

      protected void OnDisable()
      {
         InputManager.Instance.TopDownMoveEvent -= ReadMoveValue;
      }

      protected void FixedUpdate()
      {
         Move();
      }
      
      private void ReadMoveValue(InputAction.CallbackContext ctx)
      {
         print((Vector3) ctx.ReadValue<Vector2>());
         _moveVector = (Vector3) ctx.ReadValue<Vector2>();
         _wantMove = _moveVector.magnitude > 0;
      }

      private void Move()
      {
         if(!_wantMove)
            return;
         transform.position += _moveVector;
      }
   }
}
