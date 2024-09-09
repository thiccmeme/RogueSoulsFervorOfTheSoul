using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{

    private EventManager2 _eventManager2;

    [SerializeField]private GameObject _itemInventory;

    private bool _inventoryOpen;

    private PlayerInput input;

    private InputManagment inputManagment;
    // Start is called before the first frame update
    void Start()
    {
        _eventManager2 = FindObjectOfType<EventManager2>();
        inputManagment = FindFirstObjectByType<InputManagment>();
        input = inputManagment.input;
        _inventoryOpen = true;
    }

    void OnInventory()
    {
        if (_inventoryOpen)
        {
            _itemInventory.SetActive(false);
            _inventoryOpen = false;
        }
        else
        {
            _itemInventory.SetActive(true);
            _inventoryOpen = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}