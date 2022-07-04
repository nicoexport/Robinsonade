using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Architecture;

namespace Input
{
    public class InputManager : Singleton<InputManager>
    {
        public UnityEvent InteractEvent;

        public PlayerInputActions PlayerInputActions { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            PlayerInputActions = new PlayerInputActions();
            PlayerInputActions.Player.Enable();
        }

        private void OnEnable()
        {
            PlayerInputActions.Player.Interact.performed += InteractInput;
        }

        public float HorizontalInput()
        {
            return PlayerInputActions.Player.Movement.ReadValue<Vector2>().x;
        }

        public float VerticalInput()
        {
            return PlayerInputActions.Player.Movement.ReadValue<Vector2>().y;
        }

        public void InteractInput(InputAction.CallbackContext context)
        {
            InteractEvent.Invoke();
        }
    }
}
