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

    public ItemInventory itemInventory;

    public PlayerWeapon weapon;

    public Transform FirePoint;

    public PlayerInputHandler Input;

    public SpriteRenderer spriteRenderer;

    public int key;
    
    
    

    private void Start()
    {
        
        originalPosition = FindObjectOfType<hands>().transform;
        transform.position = originalPosition.position;
        _itemType = _itemSo.itemType;
        _itemManager = gameObject.AddComponent<ItemManager>();
        _door = FindFirstObjectByType<Door>();
        eventManager2 = FindFirstObjectByType<EventManager2>();
        itemInventory = FindFirstObjectByType<ItemInventory>();
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
        _itemManager.InteractEvent += UseKey;
    }

    private void Awake()
    {
        useKey = new Aydens();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Door>()&& _itemType == ItemType.Key)
        {
            _door = other.GetComponent<Door>();
            _itemManager.InteractEvent += UseKey;
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Door>() && _itemType == ItemType.Key)
        {
            _itemManager.InteractEvent -= UseKey;
            canOpen = false;
        }
    }

    private void FixedUpdate()
    {
        

    }
    
    public void UseKey()
    {
        Debug.Log("open");
        if (_itemType == ItemType.Key && _door!= null)
        {
            eventManager2.RunKeyUsedEvent();
            _door.UnlockDoor();
            _door.OpenDoor();
            Destroy(this.gameObject);
        }
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
