using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Architecture;

namespace Input
{
    public class InputManager : Singleton<InputManager>
    {
        public static event Action<InputAction.CallbackContext> InteractEvent;
        private PlayerInputActions _playerInputActions;
        
        protected override void Awake()
        {
            base.Awake();
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
        }

        protected void OnEnable()
        {
            _playerInputActions.Player.Interact.performed += InteractInput;
        }

        protected void OnDisable()
        {
            _playerInputActions.Player.Interact.performed -= InteractInput;
        }

        public float HorizontalInput()
        {
            return _playerInputActions.Player.Movement.ReadValue<Vector2>().x;
        }

        public float VerticalInput()
        {
            return _playerInputActions.Player.Movement.ReadValue<Vector2>().y;
        }

        private void InteractInput(InputAction.CallbackContext context)
        {
            InteractEvent?.Invoke(context);
        }
    }
}
