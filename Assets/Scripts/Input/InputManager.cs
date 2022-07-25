using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Architecture;

namespace Input
{
    public class InputManager : Singleton<InputManager>
    {
        public event Action<InputAction.CallbackContext> InteractEvent;
        public event Action<InputAction.CallbackContext> TopDownMoveEvent;
        public PlayerInputActions PlayerInputActions { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();
            PlayerInputActions = new PlayerInputActions();
            PlayerInputActions.Sidescroll.Enable();
        }

        protected void OnEnable()
        {
            PlayerInputActions.Sidescroll.Interact.performed += InteractInput;
            PlayerInputActions.Topdown.Move.performed += TopDownMovementInput;
        }


        protected void OnDisable()
        {
            PlayerInputActions.Sidescroll.Interact.performed -= InteractInput;
            PlayerInputActions.Topdown.Move.performed -= TopDownMovementInput;
        }

        public void ToggleActionMap(InputActionMap map)
        {
            if (map.enabled)
                return;
            PlayerInputActions.Disable();
            map.Enable();
        }

        public float HorizontalInput()
        {
            return PlayerInputActions.Sidescroll.Movement.ReadValue<Vector2>().x;
        }

        public float VerticalInput()
        {
            return PlayerInputActions.Sidescroll.Movement.ReadValue<Vector2>().y;
        }

        void TopDownMovementInput(InputAction.CallbackContext ctx)
        {
            TopDownMoveEvent?.Invoke(ctx);
        }
        
        private void InteractInput(InputAction.CallbackContext context)
        {
            InteractEvent?.Invoke(context);
        }
        
        
    }
}
