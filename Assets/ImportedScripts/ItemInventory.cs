using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemInventory : MonoBehaviour
{
    private EventManager2 _eventManager2;
    private GameObject _inventoryButton;
    public ItemSO _itemSo;
    public Dictionary<GameObject, int> Buttons = new Dictionary<GameObject, int>();
    public int key;

    private void Start()
    {
        _eventManager2 = FindObjectOfType<EventManager2>();
        _eventManager2._ManagedEvent += AddItem;
    }

    public void AddItem()
    {
        _inventoryButton = _itemSo.inventoryButton;
        Debug.Log(_itemSo);
        key++;
        bool exists = Buttons.TryAdd(_inventoryButton, key);
        if (exists)
        {
            GameObject newInventory = Instantiate(_inventoryButton, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, transform);
        }
        else
        {
            Debug.Log("allready exists");
        }
    }

    public void RemoveItem(InventoryButton button)
    {
        Debug.Log(button);
        Buttons.Remove(button.gameObject);
        
    }
    
}
