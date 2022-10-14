using System;
using Architecture;
using UnityEngine;

namespace Puzzle
{
   public class TopDownPlayerController : MonoBehaviour
   {

      private TopDownCharacter _character;
      private Vector2 _moveVector;
      private Vector2 _prevVector;
      private bool _pushButtonIsPressed;
     

      protected void Awake()
      {
         InputManager.Instance.ToggleActionMap(InputManager.Instance.PlayerInputActions.Topdown);
         if(TryGetComponent<TopDownCharacter>(out var character))
         {
            _character = character;
         }
      }

      protected void Update()
      {
         ReadInput();
      }

      protected void FixedUpdate()
      {
         HandleInput();
      }

      private void HandleInput()
      {
         _character.SetStance(_pushButtonIsPressed ? TopDownCharacter.Stance.Pushing : TopDownCharacter.Stance.Regular);
         HandleMovement();
      }

      private void HandleMovement()
      {
         if (_moveVector.magnitude == 0)
            return;
         _character.TryMoveTo(GetDirection(_moveVector));
      }
      

      private void ReadInput()
      {
         _pushButtonIsPressed = InputManager.Instance.PlayerInputActions.Topdown.Push.ReadValue<float>() > 0f;
         _moveVector = GetMoveVector();
      }

      private Vector2 GetMoveVector()
      {
         var vector = InputManager.Instance.PlayerInputActions.Topdown.Move.ReadValue<Vector2>();
         if (vector == Vector2.zero)
            return vector;
         if (vector != Vector2.up && vector != Vector2.down && vector != Vector2.right && vector != Vector2.left)
            return vector - _prevVector;
         _prevVector = vector;
         return vector;
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
   }
}
