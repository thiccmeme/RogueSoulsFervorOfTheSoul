using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    public ItemSO _itemSo;
    private Button _button;
    private Transform _transform;
    private TMP_Text _text;
    [SerializeField] private TMP_Text descriptionText;
    private EquipableItem _equipable;
    private EquipableItem _item;
    private EventManager2 _eventManager2;
    private WeaponOffsetHandle weaponOffsetHandle;
    private ItemType itemType;
    Dictionary<EquipableItem, ItemType> itemDictionary = new Dictionary<EquipableItem, ItemType>();
    public bool Disabled;
    public ItemInventory itemInventory;
    public int key;

    private void Awake()
    {
        _button = GetComponent<Button>();
        image = GetComponent<Image>();
        _text = GetComponentInChildren<TMP_Text>();
        _transform = FindFirstObjectByType<WeaponOffsetHandle>().transform;
        _eventManager2 = FindObjectOfType<EventManager2>();
        image.sprite = _itemSo._sprite;
        _equipable = _itemSo.equipableItem;
        _text.text = _itemSo.ItemName;
        descriptionText.text = _itemSo.ItemDescription;
        descriptionText.enabled = false;
        itemInventory = FindFirstObjectByType<ItemInventory>();
        
        if (_itemSo.itemType == ItemType.Weapon)
        {
            
        }

        if (_itemSo.itemType == ItemType.Key)
        {
            
        }
    }

    private void Start()
    {
        _button.onClick.AddListener(ItemSet);
        

    }

    public void Destroy()
    {
        itemInventory.RemoveItem(_itemSo);
        Destroy(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionText.enabled = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionText.enabled = false;
    }

    private void ItemSet()
    {
        _equipable._itemSo = _itemSo;
        _equipable = _itemSo.equipableItem;
        _item = FindAnyObjectByType<EquipableItem>();

        if (_item == null)
        {
            EquipableItem Guntemp = Instantiate(_equipable, _transform);
            Guntemp.transform.localRotation = Quaternion.Euler(0,0,0);
            Guntemp.inventoryButton = this;
            _eventManager2.RunEquipedEvent();
        }
        else
        {
            return;
        }
        
            //Debug.Log("Not Enought of item or already have item equipped");
    }
        
        
    
}
