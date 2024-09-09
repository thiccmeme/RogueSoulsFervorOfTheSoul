using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ManagedEvent();
public delegate void ItemEquipedEvent();
public class EventManager2 : MonoBehaviour
{
    public event ManagedEvent _ManagedEvent;
    
    public void RunEvent()
    {
        InvokeEvent();
    }

    protected virtual void InvokeEvent()
    {
        _ManagedEvent?.Invoke();
    }
    
    public event ItemEquipedEvent _equipedEvent;

    public void RunEquipedEvent()
    {
        InvokeEquipedEvent();
    }

    protected virtual void InvokeEquipedEvent()
    {
        _equipedEvent?.Invoke();
    }
}
