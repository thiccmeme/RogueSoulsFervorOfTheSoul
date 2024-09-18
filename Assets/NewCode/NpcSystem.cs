using System;
using TMPro;
using Unity.Mathematics;
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
    [SerializeField] private int PositiveTreshHold;
    [SerializeField] private int NegativeTreshHold;
    [SerializeField] private int currentHonor;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    [SerializeField] private GameObject goodReward;
    [SerializeField] private GameObject badReward;
    [SerializeField] private bool finished = false;
    public int index = 0;

    private EntityStats entityStats;

    private EventManager2 eventManager2;
    
    

    private void SwitchMessageGood()
    {
        CurrentSo = dialogGood;

    }

    public void OnTalk()
    {
        eventManager2.RunNextEvent();
    }

    public void Interact()
    {
        IndexText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && triggered == false )
        {
            eventManager2._NextEvent += Interact;
            playerInputHandler.UpdateNpcSystemReference(this);
            
            triggered = true;
            text.enabled = true;
            //SwitchMessageBad();
            //IndexText();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            eventManager2._NextEvent -= Interact;
            text.enabled = false;
            triggered = false;
        }
        
    }

    private void SwitchMessageBad()
    {
        CurrentSo = dialogBad;
    }


    private void IndexText()
    {
        if (finished == false)
        {
            index++;
        }

        Debug.Log(dialogassets.Length);
        if (index <= dialogassets.Length)
        {
            
            CurrentSo.IncreaseIndex();
            text.text = CurrentSo.currentDialog;
        }
        else
        {
            if (finished)
            {
                return;
            }
            else
            {
                Reward();
                finished = true;
            }

        }

    }

    public void HonorNegativeThreshold()
    {
        currentHonor--;
        Debug.Log(currentHonor);
        if (currentHonor <= NegativeTreshHold)
        {
            CurrentSo = dialogBad;
            index = 1;
            text.text = CurrentSo.currentDialog;
        }
    }

    public void Reward()
    {
        if (currentHonor >= PositiveTreshHold && goodReward != null)
        {
             var good = Instantiate(goodReward, new Vector3(transform.localPosition.x, transform.localPosition.y,transform.localPosition.z), quaternion.Euler(0,0,0));
             good.transform.localRotation = Quaternion.Euler(0,0,0);
             good.transform.localPosition = this.transform.localPosition;
             Debug.Log(good);
        }

        if (currentHonor == 0)
        {
            return;
        }

        if (currentHonor <= NegativeTreshHold && badReward!= null)
        {
            var bad = Instantiate(badReward, new Vector3(transform.localPosition.x, transform.localPosition.y,transform.localPosition.z), quaternion.Euler(0,0,0));
            bad.transform.localRotation = Quaternion.Euler(0,0,0);
            bad.transform.localPosition = this.transform.localPosition;
            Debug.Log(bad);
        }
    }
    
    public void HonorPositiveThreshold()
    {
        currentHonor++;
        Debug.Log(currentHonor);
        if (currentHonor >= PositiveTreshHold)
        {
            index = 1;
            CurrentSo = dialogGood;
            text.text = CurrentSo.currentDialog;
        }
    }

    private void Awake()
    {
        eventManager2 = FindFirstObjectByType<EventManager2>();
    }

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        eventManager2._honorDecreased += HonorNegativeThreshold;
        eventManager2._honorIncreased += HonorPositiveThreshold;
        eventManager2._rewardEvent += Reward;
        playerInputHandler = FindFirstObjectByType<PlayerInputHandler>();
        entityStats = GetComponent<EntityStats>();
        dialogGood.resetDialog();
        dialogBad.resetDialog();
        dialogBad.index = 0;
        dialogGood.index = 0;
        CurrentSo = dialogGood;
        dialogassets = CurrentSo.dialog;
        text.text = CurrentSo.currentDialog;
        text.enabled = false;
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
