using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class NpcSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private TMP_Text text;

    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private DialogSo dialogGood;
    [SerializeField] private DialogSo dialogBad;
    [SerializeField] private string[] dialogassets;
    [SerializeField] private DialogSo CurrentSo;
    [SerializeField] private bool triggered = false;
    public int index = 0;

    private EntityStats entityStats;

    private EventManager2 eventManager2;
    
    

    private void SwitchMessageGood()
    {
        CurrentSo = dialogGood;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && triggered == false )
        {
            triggered = true;
            SwitchMessageBad();
            IndexText();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) triggered = false;
    }

    private void SwitchMessageBad()
    {
        CurrentSo = dialogBad;

    }


    private void IndexText()
    {
        CurrentSo.IncreaseIndex();
        text.text = CurrentSo.currentDialog;
    }

    public void HonorNegativeThreshold()
    {
        dialogassets =dialogBad.dialog;
    }
    
    public void HonorPositiveThreshold()
    {
        dialogassets =dialogGood.dialog;
    }

    private void Awake()
    {
        eventManager2 = FindFirstObjectByType<EventManager2>();
    }

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        eventManager2._honorDecreased += HonorNegativeThreshold;
        entityStats = GetComponent<EntityStats>();
        CurrentSo = dialogGood;
        dialogassets = CurrentSo.dialog;
        text.text = CurrentSo.currentDialog;
        dialogBad.index = 0;
        dialogGood.index = 0;
        CurrentSo.index = 0;
        dialogGood.resetDialog();
        dialogBad.resetDialog();
        CurrentSo.resetDialog();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
