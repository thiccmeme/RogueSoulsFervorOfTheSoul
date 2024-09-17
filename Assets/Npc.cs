//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.9.0
//     from Assets/Npc.inputactions
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
using UnityEngine;

public partial class @Npc: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Npc()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Npc"",
    ""maps"": [
        {
            ""name"": ""Talk"",
            ""id"": ""ae6247c1-589f-4ca0-bd2e-45ec28c7e882"",
            ""actions"": [
                {
                    ""name"": ""Talk"",
                    ""type"": ""Button"",
                    ""id"": ""799b9a9b-be46-4067-b5eb-faa06947e6f6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e0d663f0-65fc-4da5-a5d0-4e957c4196b9"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Talk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Talk
        m_Talk = asset.FindActionMap("Talk", throwIfNotFound: true);
        m_Talk_Talk = m_Talk.FindAction("Talk", throwIfNotFound: true);
    }

    ~@Npc()
    {
        Debug.Assert(!m_Talk.enabled, "This will cause a leak and performance issues, Npc.Talk.Disable() has not been called.");
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

    // Talk
    private readonly InputActionMap m_Talk;
    private List<ITalkActions> m_TalkActionsCallbackInterfaces = new List<ITalkActions>();
    private readonly InputAction m_Talk_Talk;
    public struct TalkActions
    {
        private @Npc m_Wrapper;
        public TalkActions(@Npc wrapper) { m_Wrapper = wrapper; }
        public InputAction @Talk => m_Wrapper.m_Talk_Talk;
        public InputActionMap Get() { return m_Wrapper.m_Talk; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TalkActions set) { return set.Get(); }
        public void AddCallbacks(ITalkActions instance)
        {
            if (instance == null || m_Wrapper.m_TalkActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TalkActionsCallbackInterfaces.Add(instance);
            @Talk.started += instance.OnTalk;
            @Talk.performed += instance.OnTalk;
            @Talk.canceled += instance.OnTalk;
        }

        private void UnregisterCallbacks(ITalkActions instance)
        {
            @Talk.started -= instance.OnTalk;
            @Talk.performed -= instance.OnTalk;
            @Talk.canceled -= instance.OnTalk;
        }

        public void RemoveCallbacks(ITalkActions instance)
        {
            if (m_Wrapper.m_TalkActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITalkActions instance)
        {
            foreach (var item in m_Wrapper.m_TalkActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TalkActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TalkActions @Talk => new TalkActions(this);
    public interface ITalkActions
    {
        void OnTalk(InputAction.CallbackContext context);
    }
}
