//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Input/InputActions.inputactions
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

public partial class @InputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerLand"",
            ""id"": ""e4cec16e-ae6f-4c19-8f5b-fcd4c248749d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8367f4e8-0082-4a3d-998b-bb36b82ec494"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""b3ad547e-b4aa-4d87-9922-99c33e5abb43"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""ceb09766-4c17-4ff0-b827-e8058d662046"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d8303620-623c-4dc9-a9ed-8c89dc589943"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c7ab37f4-6abe-44f6-90f7-09a603cb8b6a"",
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
                    ""id"": ""f14c9ad3-6fee-4088-bafd-7b7ed951e5c5"",
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
                    ""id"": ""bf565d05-cc56-4d09-9244-85435186beac"",
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
                    ""id"": ""25557724-46f8-4b72-a611-7ef52109092b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d69d91f1-1320-43b9-8991-a0bcf015ee62"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.05,y=0.05)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63aa7604-86eb-4e95-844d-78c970e29619"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerLand
        m_PlayerLand = asset.FindActionMap("PlayerLand", throwIfNotFound: true);
        m_PlayerLand_Move = m_PlayerLand.FindAction("Move", throwIfNotFound: true);
        m_PlayerLand_Look = m_PlayerLand.FindAction("Look", throwIfNotFound: true);
        m_PlayerLand_Jump = m_PlayerLand.FindAction("Jump", throwIfNotFound: true);
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

    // PlayerLand
    private readonly InputActionMap m_PlayerLand;
    private IPlayerLandActions m_PlayerLandActionsCallbackInterface;
    private readonly InputAction m_PlayerLand_Move;
    private readonly InputAction m_PlayerLand_Look;
    private readonly InputAction m_PlayerLand_Jump;
    public struct PlayerLandActions
    {
        private @InputActions m_Wrapper;
        public PlayerLandActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerLand_Move;
        public InputAction @Look => m_Wrapper.m_PlayerLand_Look;
        public InputAction @Jump => m_Wrapper.m_PlayerLand_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerLand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerLandActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerLandActions instance)
        {
            if (m_Wrapper.m_PlayerLandActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerLandActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerLandActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerLandActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerLandActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerLandActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerLandActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_PlayerLandActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerLandActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerLandActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerLandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerLandActions @PlayerLand => new PlayerLandActions(this);
    public interface IPlayerLandActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
