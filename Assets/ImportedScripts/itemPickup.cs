using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private EventManager2 _eventManager2;
    public ItemSO itemSo;
    private ItemInventory _inventory;
    private Sprite _sprite;
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D collider2D;
    public EquipableItem equipableItem;
    bool alreadyPickedUp;
    private WeaponOffsetHandle weaponOffsetHandle;
    private PlayerController playerController;

    private void Start()
    {
        _inventory = FindFirstObjectByType<ItemInventory>();
        _eventManager2 = FindFirstObjectByType<EventManager2>();
        _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        collider2D = gameObject.AddComponent<CapsuleCollider2D>();
        playerController = FindFirstObjectByType<PlayerController>();
        weaponOffsetHandle = FindFirstObjectByType<WeaponOffsetHandle>();
        collider2D.isTrigger = true;
        _sprite = itemSo._sprite;
        _spriteRenderer.sprite = _sprite;
        //_spriteRenderer.sortingOrder = 3;
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (alreadyPickedUp) return;
            
            alreadyPickedUp = true;
            OnItemPickedUp();
            if (weaponOffsetHandle._weapon == null && itemSo.itemType == ItemType.Weapon)
            {
                equipableItem._itemSo = itemSo;
                equipableItem = itemSo.equipableItem;
                equipableItem = Instantiate(itemSo.equipableItem, weaponOffsetHandle.transform);
                equipableItem.transform.localRotation = Quaternion.Euler(0,0,0);
                equipableItem.inventoryButton = itemSo.equipableItem.inventoryButton;
                _eventManager2.RunEquipedEvent();
            }
            Destroy(this.gameObject);
        }
    }


    void OnItemPickedUp()
    {
        _inventory._itemSo = itemSo;
        _inventory.AddItem(itemSo);
    }
}
