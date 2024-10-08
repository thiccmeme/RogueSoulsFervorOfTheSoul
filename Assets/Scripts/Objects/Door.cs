using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [field: SerializeField]
    public bool IsLocked { get; protected set; }

    [field: SerializeField]
    public bool IsBossDoor { get; protected set; }

    public bool IsOpen { get; protected set; }

    [SerializeField]
    bool _startOpen;

    public GameObject _doorObject;

    [SerializeField]
    Sprite _unlockedSprite, _lockedSprite;

    public SpriteRenderer _doorRenderer { get; protected set; }

    private EventManager2 eventManager2;

    public EquipableItem key;

    private void Start()
    {
        _doorRenderer = GetComponentInChildren<SpriteRenderer>();
        eventManager2 = FindFirstObjectByType<EventManager2>();
        _doorObject = _doorRenderer.gameObject;

        if(IsBossDoor)
        {
            IsLocked = true;
        }

        if(IsLocked)
        {
            _doorRenderer.sprite = _lockedSprite;
        }
        else
        {
            _doorRenderer.sprite = _unlockedSprite;
        }

        if(_startOpen)
        {
            OpenDoor();
        }
        
    }

    public virtual void OpenDoor()
    {
        if(!IsLocked)
        {
            _doorObject.SetActive(false);
            IsOpen = true;
        }
    }

    public virtual void CloseDoor()
    {
        _doorObject.SetActive(true);
        IsOpen = false;
    }

    public virtual void UnlockDoor()
    {
        if(IsLocked)
        {
            _doorRenderer.sprite = _unlockedSprite;
            IsLocked = false;
        }
    }

    public void FixedUpdate()
    {
        
    }
}
