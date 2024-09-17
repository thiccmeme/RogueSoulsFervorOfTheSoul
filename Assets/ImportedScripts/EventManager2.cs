using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ManagedEvent();
public delegate void ItemEquipedEvent();

public delegate void ItemDestroyEvent();

public delegate void HonorIncreasedEvent();

public delegate void HonorDecreasedEvent();



public delegate void ItemEquipEvent();
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

    public event ItemDestroyEvent _itemDestroyed;

    public void RunDestroyItemEvent()
    {
        InvokeDestroyedEvent();
    }

    protected virtual void InvokeDestroyedEvent()
    {
        _itemDestroyed?.Invoke();
    }

    public event ItemEquipEvent _itemEquip;

    public void RunItemEquipEvent()
    {
        InvokeEquipEvent();
    }

    protected virtual void InvokeEquipEvent()
    {
        _itemEquip?.Invoke();
    }

    public HonorDecreasedEvent _honorDecreased;

    public void RunHonorDecreasedEvent()
    {
        InvokeHonorDecreased();
    }

    protected virtual void InvokeHonorDecreased()
    {
        _honorDecreased?.Invoke();
    }
    
    public HonorDecreasedEvent _honorIncreased;

    public void RunHonorincreasedEvent()
    {
        InvokeHonorIncreased();
    }

    protected virtual void InvokeHonorIncreased()
    {
        _honorIncreased?.Invoke();
    }
}
