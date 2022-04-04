// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputAction_Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputAction_Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputAction_Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputAction_Player"",
    ""maps"": [
        {
            ""name"": ""Player Controls"",
            ""id"": ""c7186429-a879-4ac0-977e-afb7446b36d6"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""4b807cf5-695d-48c3-9617-8cc6095f9005"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Value"",
                    ""id"": ""b93df693-98af-4c9d-b548-08b11a9bd274"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill"",
                    ""type"": ""Button"",
                    ""id"": ""7e3dde89-b1fb-46a9-8322-d418c0622009"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LowFlying"",
                    ""type"": ""Button"",
                    ""id"": ""bac375ca-59cb-4402-9d21-c01c3cf522b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Boosting"",
                    ""type"": ""Button"",
                    ""id"": ""301bb87a-970f-4d00-9b78-6aa3cc942bd8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Targeting"",
                    ""type"": ""Button"",
                    ""id"": ""4e1d3cee-d5b5-4326-8ab1-4259366c881f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD Key"",
                    ""id"": ""c239739c-1c0b-4052-81de-72b06b8f6e29"",
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
                    ""id"": ""d6f71229-d635-4070-bc2c-b0e116f7cb77"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""16459aca-5c38-49dc-8315-58d4547caba8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3fd04cda-7898-4eb0-9904-b667c473d95b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""80425227-27f5-469a-b93f-34351325f959"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Key"",
                    ""id"": ""bfe4c3c8-34af-4fc7-8471-821b2ef25325"",
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
                    ""id"": ""a407c7bf-b499-4f86-8da6-050bee073058"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""22c2b58f-c639-4059-826e-7a83db5d79cf"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6e5f8254-970a-4931-b41b-4425316abfe0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9c7992bd-600b-4b0b-9039-ab7d0d0bb67d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ed7b3952-6292-4c0f-bc48-151c740abaa3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05fc2add-eaf4-4eb5-956a-0d11a7cf3ee3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""LowFlying"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4594c2b-308d-4744-a0cf-0c47eb56270b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LowFlying"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9c5bca3-3e4c-4dcf-b1bf-9bdfd75c2a0e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Boosting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0851638c-8b0b-47c9-8ba2-c7aa3a695119"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Boosting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adcb2b17-b76b-4632-95f4-bbe8c5bc8872"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Targeting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
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
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player Controls
        m_PlayerControls = asset.FindActionMap("Player Controls", throwIfNotFound: true);
        m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControls_Attack = m_PlayerControls.FindAction("Attack", throwIfNotFound: true);
        m_PlayerControls_Skill = m_PlayerControls.FindAction("Skill", throwIfNotFound: true);
        m_PlayerControls_LowFlying = m_PlayerControls.FindAction("LowFlying", throwIfNotFound: true);
        m_PlayerControls_Boosting = m_PlayerControls.FindAction("Boosting", throwIfNotFound: true);
        m_PlayerControls_Targeting = m_PlayerControls.FindAction("Targeting", throwIfNotFound: true);
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

    // Player Controls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Movement;
    private readonly InputAction m_PlayerControls_Attack;
    private readonly InputAction m_PlayerControls_Skill;
    private readonly InputAction m_PlayerControls_LowFlying;
    private readonly InputAction m_PlayerControls_Boosting;
    private readonly InputAction m_PlayerControls_Targeting;
    public struct PlayerControlsActions
    {
        private @InputAction_Player m_Wrapper;
        public PlayerControlsActions(@InputAction_Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
        public InputAction @Attack => m_Wrapper.m_PlayerControls_Attack;
        public InputAction @Skill => m_Wrapper.m_PlayerControls_Skill;
        public InputAction @LowFlying => m_Wrapper.m_PlayerControls_LowFlying;
        public InputAction @Boosting => m_Wrapper.m_PlayerControls_Boosting;
        public InputAction @Targeting => m_Wrapper.m_PlayerControls_Targeting;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAttack;
                @Skill.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSkill;
                @Skill.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSkill;
                @Skill.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSkill;
                @LowFlying.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLowFlying;
                @LowFlying.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLowFlying;
                @LowFlying.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLowFlying;
                @Boosting.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBoosting;
                @Boosting.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBoosting;
                @Boosting.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBoosting;
                @Targeting.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnTargeting;
                @Targeting.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnTargeting;
                @Targeting.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnTargeting;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Skill.started += instance.OnSkill;
                @Skill.performed += instance.OnSkill;
                @Skill.canceled += instance.OnSkill;
                @LowFlying.started += instance.OnLowFlying;
                @LowFlying.performed += instance.OnLowFlying;
                @LowFlying.canceled += instance.OnLowFlying;
                @Boosting.started += instance.OnBoosting;
                @Boosting.performed += instance.OnBoosting;
                @Boosting.canceled += instance.OnBoosting;
                @Targeting.started += instance.OnTargeting;
                @Targeting.performed += instance.OnTargeting;
                @Targeting.canceled += instance.OnTargeting;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
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
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSkill(InputAction.CallbackContext context);
        void OnLowFlying(InputAction.CallbackContext context);
        void OnBoosting(InputAction.CallbackContext context);
        void OnTargeting(InputAction.CallbackContext context);
    }
}
