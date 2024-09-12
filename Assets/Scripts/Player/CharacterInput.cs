//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Student_Assets/Ayden's/Inputs/CharacterInput.inputactions
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

public partial class @CharacterInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInput"",
    ""maps"": [
        {
            ""name"": ""CharacterMovement"",
            ""id"": ""037259d6-97aa-46b3-95c9-f437f1601fff"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f4897846-4ec6-4b6d-8789-42ca28e5e09d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim (Mouse)"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5fcf4373-d801-43a0-98e6-248e1c37477f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Aim (Controller)"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1fc4bbdf-3f70-4291-88e4-f9c93cfa191f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0ef040d9-6c26-4ccb-bf9e-80f1b2f3c233"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bf214eaf-0451-4481-a7f8-3094408d70e8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c989160c-6508-4107-81b8-1eaeb6dcc117"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""971a5761-db70-43b1-ac96-c75bca6fbddb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1edc339b-8a66-465f-8a78-ed53a66fef4b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""41a553ab-6bcb-4821-8664-6a2d21c29209"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.25,max=0.925)"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dd280b8b-272c-4218-b778-f5e258495d6c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2b876d3e-69bc-43f7-8ec7-95f060c2cdd9"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""38245115-f0d1-4b25-b15e-aca4a9499494"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0b6c55ea-345b-43a3-aaa9-222c7a66e6c6"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3c0fe409-b5c4-4921-8c17-559991f640c6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim (Mouse)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""b22396d0-f92b-496c-b79f-47f94cc57270"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim (Controller)"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b5a3e69c-e3ef-4ea1-90f9-ce85eca1806e"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim (Controller)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ae20e066-5260-40e0-81c1-62411765aa43"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim (Controller)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""84748676-ee6a-4d83-b8a9-e43342f3b091"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim (Controller)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e1be84bc-9c0e-4411-aff5-e190d73a844c"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim (Controller)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""CharacterActions"",
            ""id"": ""3c3030c6-e377-4a52-b530-c8ee5d737de5"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""01d8787f-96a8-4d29-bb5a-a8cb754fead0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DodgeRoll"",
                    ""type"": ""Button"",
                    ""id"": ""f87993d9-7e63-4734-a43a-b7d9d482ac56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenWeaponWheel"",
                    ""type"": ""Button"",
                    ""id"": ""b5a54461-6d6f-42c8-935a-6de247c26aa2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5bc93da3-7bdd-44c0-9d84-6338073d478e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""e3d8881c-9e59-477b-baed-0f8b8d917001"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SlotBinding"",
                    ""type"": ""Value"",
                    ""id"": ""cbeb6de3-f6b3-4780-839e-e741b970976a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""ba861141-77cf-4285-b34b-48c10cdf810f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StopInteract"",
                    ""type"": ""Button"",
                    ""id"": ""9ce60408-5e0f-49a6-a613-ac1541bd53c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OnShoot"",
                    ""type"": ""Button"",
                    ""id"": ""908be62c-ca1b-4996-9127-f6e40fcb237f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Unequip"",
                    ""type"": ""Button"",
                    ""id"": ""3afa239c-eb35-4e0b-a819-0d9870cab29c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""080035e4-9d97-403f-8f0b-f984492bef34"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a1a6791-0406-4b3a-828f-a049b79b9c9b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db203f77-8a71-47df-9d51-b6f57d5ff7c3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74fec6cf-43c4-4897-8f0d-6511b4fb1459"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe08304b-e16b-4643-b85b-004b1d392077"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenWeaponWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8325e03b-6f1b-4c9f-9aa6-fcc2d78502f3"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenWeaponWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c7f7bd7-512d-4bc1-9913-50710b7deecf"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4a0986c-71e0-4500-86d2-075f46d8e2d7"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e4c3905-a140-4a52-b847-7d28f0c349c9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""944210cb-2c96-4432-9007-5d10eeceb67d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""3c3a2de6-7762-4918-aa86-58ca3b76acd8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3c93b6e1-1285-48b8-88b9-05a9f3d4e0e3"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6afe6a71-5706-4dc2-b3fa-f54038210ff2"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6cc76750-b1b1-4383-9445-6e244dae0723"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""03c267d6-032b-447e-8461-88885e27a68f"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""644d575a-ede3-40f7-994e-223e31ca483d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9550772e-ea74-40a1-995b-00244a227b92"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c1017fdd-91b2-461a-ba6a-02baf03ba9cc"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d9d030df-953e-4579-96b6-a5f3c59de7a9"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e2cfe52f-8b58-468e-8f0d-21bbe377dcf4"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlotBinding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ce2e9c19-9182-4a8c-a1e7-8aab928a7afc"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51d6e818-5a4f-41a5-83f5-2fbd07cbb080"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db427c72-612d-457c-9340-7aa9488d6e6a"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c8f176d-715c-4b76-8db8-8034759ac828"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d213352-4cef-44aa-a661-22635d3af383"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60e4f666-a855-4e22-9825-400339d5e383"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Unequip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterMovement
        m_CharacterMovement = asset.FindActionMap("CharacterMovement", throwIfNotFound: true);
        m_CharacterMovement_Movement = m_CharacterMovement.FindAction("Movement", throwIfNotFound: true);
        m_CharacterMovement_AimMouse = m_CharacterMovement.FindAction("Aim (Mouse)", throwIfNotFound: true);
        m_CharacterMovement_AimController = m_CharacterMovement.FindAction("Aim (Controller)", throwIfNotFound: true);
        // CharacterActions
        m_CharacterActions = asset.FindActionMap("CharacterActions", throwIfNotFound: true);
        m_CharacterActions_Attack = m_CharacterActions.FindAction("Attack", throwIfNotFound: true);
        m_CharacterActions_DodgeRoll = m_CharacterActions.FindAction("DodgeRoll", throwIfNotFound: true);
        m_CharacterActions_OpenWeaponWheel = m_CharacterActions.FindAction("OpenWeaponWheel", throwIfNotFound: true);
        m_CharacterActions_Interact = m_CharacterActions.FindAction("Interact", throwIfNotFound: true);
        m_CharacterActions_PauseMenu = m_CharacterActions.FindAction("PauseMenu", throwIfNotFound: true);
        m_CharacterActions_SlotBinding = m_CharacterActions.FindAction("SlotBinding", throwIfNotFound: true);
        m_CharacterActions_Reload = m_CharacterActions.FindAction("Reload", throwIfNotFound: true);
        m_CharacterActions_StopInteract = m_CharacterActions.FindAction("StopInteract", throwIfNotFound: true);
        m_CharacterActions_OnShoot = m_CharacterActions.FindAction("OnShoot", throwIfNotFound: true);
        m_CharacterActions_Unequip = m_CharacterActions.FindAction("Unequip", throwIfNotFound: true);
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

    // CharacterMovement
    private readonly InputActionMap m_CharacterMovement;
    private List<ICharacterMovementActions> m_CharacterMovementActionsCallbackInterfaces = new List<ICharacterMovementActions>();
    private readonly InputAction m_CharacterMovement_Movement;
    private readonly InputAction m_CharacterMovement_AimMouse;
    private readonly InputAction m_CharacterMovement_AimController;
    public struct CharacterMovementActions
    {
        private @CharacterInput m_Wrapper;
        public CharacterMovementActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterMovement_Movement;
        public InputAction @AimMouse => m_Wrapper.m_CharacterMovement_AimMouse;
        public InputAction @AimController => m_Wrapper.m_CharacterMovement_AimController;
        public InputActionMap Get() { return m_Wrapper.m_CharacterMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterMovementActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterMovementActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @AimMouse.started += instance.OnAimMouse;
            @AimMouse.performed += instance.OnAimMouse;
            @AimMouse.canceled += instance.OnAimMouse;
            @AimController.started += instance.OnAimController;
            @AimController.performed += instance.OnAimController;
            @AimController.canceled += instance.OnAimController;
        }

        private void UnregisterCallbacks(ICharacterMovementActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @AimMouse.started -= instance.OnAimMouse;
            @AimMouse.performed -= instance.OnAimMouse;
            @AimMouse.canceled -= instance.OnAimMouse;
            @AimController.started -= instance.OnAimController;
            @AimController.performed -= instance.OnAimController;
            @AimController.canceled -= instance.OnAimController;
        }

        public void RemoveCallbacks(ICharacterMovementActions instance)
        {
            if (m_Wrapper.m_CharacterMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterMovementActions @CharacterMovement => new CharacterMovementActions(this);

    // CharacterActions
    private readonly InputActionMap m_CharacterActions;
    private List<ICharacterActionsActions> m_CharacterActionsActionsCallbackInterfaces = new List<ICharacterActionsActions>();
    private readonly InputAction m_CharacterActions_Attack;
    private readonly InputAction m_CharacterActions_DodgeRoll;
    private readonly InputAction m_CharacterActions_OpenWeaponWheel;
    private readonly InputAction m_CharacterActions_Interact;
    private readonly InputAction m_CharacterActions_PauseMenu;
    private readonly InputAction m_CharacterActions_SlotBinding;
    private readonly InputAction m_CharacterActions_Reload;
    private readonly InputAction m_CharacterActions_StopInteract;
    private readonly InputAction m_CharacterActions_OnShoot;
    private readonly InputAction m_CharacterActions_Unequip;
    public struct CharacterActionsActions
    {
        private @CharacterInput m_Wrapper;
        public CharacterActionsActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_CharacterActions_Attack;
        public InputAction @DodgeRoll => m_Wrapper.m_CharacterActions_DodgeRoll;
        public InputAction @OpenWeaponWheel => m_Wrapper.m_CharacterActions_OpenWeaponWheel;
        public InputAction @Interact => m_Wrapper.m_CharacterActions_Interact;
        public InputAction @PauseMenu => m_Wrapper.m_CharacterActions_PauseMenu;
        public InputAction @SlotBinding => m_Wrapper.m_CharacterActions_SlotBinding;
        public InputAction @Reload => m_Wrapper.m_CharacterActions_Reload;
        public InputAction @StopInteract => m_Wrapper.m_CharacterActions_StopInteract;
        public InputAction @OnShoot => m_Wrapper.m_CharacterActions_OnShoot;
        public InputAction @Unequip => m_Wrapper.m_CharacterActions_Unequip;
        public InputActionMap Get() { return m_Wrapper.m_CharacterActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActionsActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Add(instance);
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @DodgeRoll.started += instance.OnDodgeRoll;
            @DodgeRoll.performed += instance.OnDodgeRoll;
            @DodgeRoll.canceled += instance.OnDodgeRoll;
            @OpenWeaponWheel.started += instance.OnOpenWeaponWheel;
            @OpenWeaponWheel.performed += instance.OnOpenWeaponWheel;
            @OpenWeaponWheel.canceled += instance.OnOpenWeaponWheel;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @PauseMenu.started += instance.OnPauseMenu;
            @PauseMenu.performed += instance.OnPauseMenu;
            @PauseMenu.canceled += instance.OnPauseMenu;
            @SlotBinding.started += instance.OnSlotBinding;
            @SlotBinding.performed += instance.OnSlotBinding;
            @SlotBinding.canceled += instance.OnSlotBinding;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
            @StopInteract.started += instance.OnStopInteract;
            @StopInteract.performed += instance.OnStopInteract;
            @StopInteract.canceled += instance.OnStopInteract;
            @OnShoot.started += instance.OnOnShoot;
            @OnShoot.performed += instance.OnOnShoot;
            @OnShoot.canceled += instance.OnOnShoot;
            @Unequip.started += instance.OnUnequip;
            @Unequip.performed += instance.OnUnequip;
            @Unequip.canceled += instance.OnUnequip;
        }

        private void UnregisterCallbacks(ICharacterActionsActions instance)
        {
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @DodgeRoll.started -= instance.OnDodgeRoll;
            @DodgeRoll.performed -= instance.OnDodgeRoll;
            @DodgeRoll.canceled -= instance.OnDodgeRoll;
            @OpenWeaponWheel.started -= instance.OnOpenWeaponWheel;
            @OpenWeaponWheel.performed -= instance.OnOpenWeaponWheel;
            @OpenWeaponWheel.canceled -= instance.OnOpenWeaponWheel;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @PauseMenu.started -= instance.OnPauseMenu;
            @PauseMenu.performed -= instance.OnPauseMenu;
            @PauseMenu.canceled -= instance.OnPauseMenu;
            @SlotBinding.started -= instance.OnSlotBinding;
            @SlotBinding.performed -= instance.OnSlotBinding;
            @SlotBinding.canceled -= instance.OnSlotBinding;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
            @StopInteract.started -= instance.OnStopInteract;
            @StopInteract.performed -= instance.OnStopInteract;
            @StopInteract.canceled -= instance.OnStopInteract;
            @OnShoot.started -= instance.OnOnShoot;
            @OnShoot.performed -= instance.OnOnShoot;
            @OnShoot.canceled -= instance.OnOnShoot;
            @Unequip.started -= instance.OnUnequip;
            @Unequip.performed -= instance.OnUnequip;
            @Unequip.canceled -= instance.OnUnequip;
        }

        public void RemoveCallbacks(ICharacterActionsActions instance)
        {
            if (m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterActionsActions @CharacterActions => new CharacterActionsActions(this);
    public interface ICharacterMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAimMouse(InputAction.CallbackContext context);
        void OnAimController(InputAction.CallbackContext context);
    }
    public interface ICharacterActionsActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnDodgeRoll(InputAction.CallbackContext context);
        void OnOpenWeaponWheel(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
        void OnSlotBinding(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnStopInteract(InputAction.CallbackContext context);
        void OnOnShoot(InputAction.CallbackContext context);
        void OnUnequip(InputAction.CallbackContext context);
    }
}
