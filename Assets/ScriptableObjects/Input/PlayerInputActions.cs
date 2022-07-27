//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/ScriptableObjects/Input/INP_PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""INP_PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Sidescroll"",
            ""id"": ""2d52d019-29a1-4ecd-bcdf-5482f2dc2460"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a151d5ae-67c4-4e51-bfce-d6a167b66840"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""8735fe20-5ff8-417b-89e6-a61aebb9bc2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""833e7bcc-4084-4630-9b1c-5918bde76bf1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f595c35a-ac28-45a7-8a2a-15e93f84cbee"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ff1165b6-1a57-4a59-bcaa-c0d5ce544187"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""37205e49-1416-4344-b28c-310436addf03"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cb92f010-4101-4721-810e-980b14fd2f35"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f320b107-6e42-40e9-b4ab-7d496b56f7a1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ARROWKEYS"",
                    ""id"": ""fe62df77-36b1-4223-b767-efa6420fbabc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""be8bdc9d-0e46-4592-b231-bdfe4c74f9b5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5eb53821-3a0b-4afe-a5fb-30406a72102f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5aa07d8a-cc0f-47eb-8a04-2fd021eed99d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7d4ac576-99cd-4cc5-8999-aa79231b061d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""087c1862-ce63-4d1b-8561-930b5af56c66"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d2ae439-b25e-479c-b0a6-cc396637f6c9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Topdown"",
            ""id"": ""39abf853-ed8a-41a7-8dc8-48ecbc9eb6c5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1481317b-2a8f-42ce-b4e5-0f12d745e1cf"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveX"",
                    ""type"": ""Value"",
                    ""id"": ""338e5070-808d-4c8c-8c47-568b0f6ea55e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveY"",
                    ""type"": ""Value"",
                    ""id"": ""e1a571fe-e6e7-4eb9-96ea-f90d35e10936"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8cf5b7cb-dad8-4c77-9d83-8f3a046ecd0c"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8d83b6ec-9acd-4f2e-bb78-44753a6093ee"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8745504e-93ea-4f8f-a9cb-25bd856f7a6b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""67aefa00-6292-40f1-8b63-32ff7a0c7e6c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""205fbfbd-f5af-4e30-bdc5-647d5fe1ca8a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4f5012f2-3396-4c26-bf75-c0f1a7649ad6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8ad33059-a351-43b7-9dd1-08108baf7d78"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""77fc99e0-aff6-4b0c-b6b4-ffe8cdaed382"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6dee173c-1805-42d2-ae72-d67063ed221d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c7297a3a-a078-4144-8732-76fc73108a09"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""464b056f-d452-4e80-bc66-9487b06f1125"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Sidescroll
        m_Sidescroll = asset.FindActionMap("Sidescroll", throwIfNotFound: true);
        m_Sidescroll_Movement = m_Sidescroll.FindAction("Movement", throwIfNotFound: true);
        m_Sidescroll_Interact = m_Sidescroll.FindAction("Interact", throwIfNotFound: true);
        // Topdown
        m_Topdown = asset.FindActionMap("Topdown", throwIfNotFound: true);
        m_Topdown_Move = m_Topdown.FindAction("Move", throwIfNotFound: true);
        m_Topdown_MoveX = m_Topdown.FindAction("MoveX", throwIfNotFound: true);
        m_Topdown_MoveY = m_Topdown.FindAction("MoveY", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Sidescroll
    private readonly InputActionMap m_Sidescroll;
    private ISidescrollActions m_SidescrollActionsCallbackInterface;
    private readonly InputAction m_Sidescroll_Movement;
    private readonly InputAction m_Sidescroll_Interact;
    public struct SidescrollActions
    {
        private @PlayerInputActions m_Wrapper;
        public SidescrollActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Sidescroll_Movement;
        public InputAction @Interact => m_Wrapper.m_Sidescroll_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Sidescroll; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SidescrollActions set) { return set.Get(); }
        public void SetCallbacks(ISidescrollActions instance)
        {
            if (m_Wrapper.m_SidescrollActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_SidescrollActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_SidescrollActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_SidescrollActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_SidescrollActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_SidescrollActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_SidescrollActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_SidescrollActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public SidescrollActions @Sidescroll => new SidescrollActions(this);

    // Topdown
    private readonly InputActionMap m_Topdown;
    private ITopdownActions m_TopdownActionsCallbackInterface;
    private readonly InputAction m_Topdown_Move;
    private readonly InputAction m_Topdown_MoveX;
    private readonly InputAction m_Topdown_MoveY;
    public struct TopdownActions
    {
        private @PlayerInputActions m_Wrapper;
        public TopdownActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Topdown_Move;
        public InputAction @MoveX => m_Wrapper.m_Topdown_MoveX;
        public InputAction @MoveY => m_Wrapper.m_Topdown_MoveY;
        public InputActionMap Get() { return m_Wrapper.m_Topdown; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TopdownActions set) { return set.Get(); }
        public void SetCallbacks(ITopdownActions instance)
        {
            if (m_Wrapper.m_TopdownActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TopdownActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TopdownActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TopdownActionsCallbackInterface.OnMove;
                @MoveX.started -= m_Wrapper.m_TopdownActionsCallbackInterface.OnMoveX;
                @MoveX.performed -= m_Wrapper.m_TopdownActionsCallbackInterface.OnMoveX;
                @MoveX.canceled -= m_Wrapper.m_TopdownActionsCallbackInterface.OnMoveX;
                @MoveY.started -= m_Wrapper.m_TopdownActionsCallbackInterface.OnMoveY;
                @MoveY.performed -= m_Wrapper.m_TopdownActionsCallbackInterface.OnMoveY;
                @MoveY.canceled -= m_Wrapper.m_TopdownActionsCallbackInterface.OnMoveY;
            }
            m_Wrapper.m_TopdownActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MoveX.started += instance.OnMoveX;
                @MoveX.performed += instance.OnMoveX;
                @MoveX.canceled += instance.OnMoveX;
                @MoveY.started += instance.OnMoveY;
                @MoveY.performed += instance.OnMoveY;
                @MoveY.canceled += instance.OnMoveY;
            }
        }
    }
    public TopdownActions @Topdown => new TopdownActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ISidescrollActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface ITopdownActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMoveX(InputAction.CallbackContext context);
        void OnMoveY(InputAction.CallbackContext context);
    }
}
