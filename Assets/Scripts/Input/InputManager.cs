using Architecture;

namespace Input
{
   public class InputManager : Singleton<InputManager>
   {
      public PlayerInputActions PlayerInputActions { get; private set; }
      
      protected override void Awake()
      {
        base.Awake();
        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Player.Enable();
      }
      
      public float HorizontalInput()
      {
        return PlayerInputActions.Player.Movement.ReadValue<UnityEngine.Vector2>().x;
      }

      public float VerticalInput()
      {
         return PlayerInputActions.Player.Movement.ReadValue<UnityEngine.Vector2>().y;
      }
   }
}
