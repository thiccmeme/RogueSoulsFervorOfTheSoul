using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemInventory : MonoBehaviour
{
    private EventManager2 _eventManager2;
    private InventoryButton _inventoryButton;
    public ItemSO _itemSo;
    public Dictionary<ItemSO, int> Buttons = new Dictionary<ItemSO, int>();
    private List<ItemSO> OtherButtons = new List<ItemSO>();
    public int key = 1;

    private void Start()
    {
        //_eventManager2 = FindObjectOfType<EventManager2>();
        //_eventManager2._ManagedEvent += AddItem;
    }

    public void AddItem(ItemSO item)
    {
        Debug.Log(_itemSo);
        _itemSo = item;
        key++;
        bool exists = Buttons.TryAdd(_itemSo, key);
        if (!OtherButtons.Contains(_itemSo))
        {
            OtherButtons.Add(_itemSo);
            _inventoryButton = Instantiate(_itemSo.inventoryButton.gameObject,new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, transform).GetComponent<InventoryButton>();
            _inventoryButton.key = key;
        }
        else
        {
            Debug.Log("allready exists");
        }
    }

    public void RemoveItem(ItemSO item )
    {
        OtherButtons.Remove(item);
        Debug.Log(item);
        //Buttons.Remove(item);
        
    }
    
}
