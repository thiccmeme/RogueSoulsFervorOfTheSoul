using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void Interact();

public class EquipableItem : MonoBehaviour
{
    private Transform originalPosition;

    private Door2 _door;

    public ItemSO _itemSo;

    public ItemType _itemType;
    
    [SerializeField] private float detectionRadius;

    private ItemManager _itemManager;

    private bool canOpen;
    
    public PlayerInput useKey;

    public PlayerInput playerInput;

    public GameObject _micro;

    public PlayerWeapon weapon;

    public Transform FirePoint;
    

    private void Start()
    {
        originalPosition = FindObjectOfType<hands>().transform;
        transform.position = originalPosition.position;
        transform.rotation = originalPosition.rotation;
        _itemType = _itemSo.itemType;
        _itemManager = gameObject.AddComponent<ItemManager>();
        _door = FindObjectOfType<Door2>();
        if (_itemType == ItemType.Weapon)
        {
            weapon = gameObject.AddComponent<PlayerWeapon>();
            weapon._gun = _itemSo;
            weapon.firePoint = FirePoint;
            WeaponOffsetHandle weaponOffsetHandle = FindFirstObjectByType<WeaponOffsetHandle>();
            weaponOffsetHandle.SetCurrentWeapon();
        }
    }

    private void Awake()
    {
        useKey = playerInput;
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
        if (_itemType == ItemType.Key)
        {
            _door.Interact();
        }
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
    
    private void OnUnEquip()
    {
        Destroy(this.gameObject);
    }

}
