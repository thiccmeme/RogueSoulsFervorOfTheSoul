using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    private void Awake()
    {
        if (_itemSo.itemType == ItemType.Weapon)
        {
            
        }
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
    }

    private void Start()
    {
        _button.onClick.AddListener(ItemSet);

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
        Debug.Log(_equipable);
        _equipable._itemSo = _itemSo;
        _item = FindAnyObjectByType<EquipableItem>();

        if (_item == null)
        {
            Instantiate(_equipable, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z), Quaternion.identity, _transform);
            _eventManager2.RunEquipedEvent();
        }
        else
        {
            Debug.Log("Not Enought of item or already have item equipped");
            return;
        }
        
    }
}
