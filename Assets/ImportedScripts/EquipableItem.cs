using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void Interact();

public class EquipableItem : MonoBehaviour
{
    private Transform originalPosition;

    private Door _door;

    public ItemSO _itemSo;

    public ItemType _itemType;
    
    [SerializeField] private float detectionRadius;

    private ItemManager _itemManager;

    private bool canOpen;

    private EventManager2 eventManager2;
    
    public Aydens useKey;

    public GameObject _micro;

    public PlayerWeapon weapon;

    public Transform FirePoint;

    public PlayerInputHandler Input;

    public SpriteRenderer spriteRenderer;
    
    
    

    private void Start()
    {
        originalPosition = FindObjectOfType<hands>().transform;
        transform.position = originalPosition.position;
        _itemType = _itemSo.itemType;
        _itemManager = gameObject.AddComponent<ItemManager>();
        _door = FindObjectOfType<Door>();
        eventManager2 = FindFirstObjectByType<EventManager2>();
        //eventManager2._itemDestroyed += OnUnEquip;
        //eventManager2._itemEquip += Requip;
        
        if (_itemType == ItemType.Weapon)
        {
            if (weapon == null)
            {
                weapon = gameObject.AddComponent<PlayerWeapon>();
            }
            weapon._gun = _itemSo;
            weapon.firePoint = FirePoint;
            WeaponOffsetHandle weaponOffsetHandle = FindFirstObjectByType<WeaponOffsetHandle>();
            weaponOffsetHandle.SetCurrentWeapon();
            Input = FindFirstObjectByType<PlayerInputHandler>(); 
            weapon.EnableShootInput();
            Input.UpdateItemRefernce();
            Input.UpdatePlayerWeaponReference();
        }
    }

    private void Awake()
    {
        useKey = new Aydens();
    }

    private void FixedUpdate()
    {
        
        if (_door != null && _itemType == ItemType.Key)
        {
            float distance = Vector3.Distance(_door.transform.position, this.transform.position);
            if (distance <= detectionRadius)
            {
                _itemManager.InteractEvent += UseKey;
                canOpen = true;
            }
            else
            {
                _itemManager.InteractEvent -= UseKey;
                canOpen = false;
            }
        }
        else if (_micro != null && _itemType == ItemType.Useless)
        {
            float distance = Vector3.Distance(_micro.transform.position, this.transform.position);
            if (distance <= detectionRadius)
            {
                _itemManager.InteractEvent += MicroWave;
                canOpen = true;
            }
            else
            {
                _itemManager.InteractEvent -= MicroWave;
                canOpen = false;
            }
        }

    }
    
    public void UseKey()
    {
        Debug.Log("open");
        if (_itemType == ItemType.Key)
        {
            eventManager2.RunKeyUsedEvent();
            _door.UnlockDoor();
            _door.OpenDoor();
        }
        Destroy(this.gameObject);
    }

    public void Requip()
    {
        //this.gameObject.SetActive(true);
    }

    public void MicroWave()
    {
        //_micro.Trigger();
    }
    
    
    
    private void OnUseKey()
    {
        if(canOpen)
        {
            Debug.Log("KEY");
            _itemManager.RunInteract();
        }
        else
        {
            return;
        }

    }
    
    public void OnUnequip()
    {
        Debug.Log("fuck");
        Input.UpdatePlayerWeaponReference();
        weapon.DisableShootInput();
       Destroy(this.gameObject);
    }

}
