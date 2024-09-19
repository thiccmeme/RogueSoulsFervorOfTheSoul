using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Random = System.Random;

public class NpcSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private TMP_Text text;

    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] protected DialogSo dialogGood;
    [SerializeField] protected DialogSo dialogBad;
    [SerializeField] protected string[] dialogassets;
    [SerializeField] protected DialogSo CurrentSo;
    [SerializeField] protected bool triggered = false;
    [SerializeField] protected int PositiveTreshHold;
    [SerializeField] protected int NegativeTreshHold;
    [SerializeField] protected int currentHonor;
    [SerializeField] protected PlayerInputHandler playerInputHandler;
    [SerializeField] protected GameObject goodReward;
    [SerializeField] protected GameObject badReward;
    [SerializeField] protected bool finished = false;
    protected bool targetInRange;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Transform target;
    [SerializeField] protected float detectionRadius = 12;
    public int index = 0;
    [SerializeField] protected PlayerWeapon enemyGun;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected TMP_FontAsset font;

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

    private void becomeAgressive()
    {
        Debug.Log("agressive");
        if (targetInRange && agent != null)
        {
            enemy.Speed = 3;
                agent.speed = 3;
            enemy.isRanged = true;
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
            text.color = Color.red;
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

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, this.transform.position);

        if (distance <= detectionRadius)
        {
            targetInRange = true;
        }
        else
        {
            targetInRange = false;
        }
    }

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        eventManager2._honorDecreased += HonorNegativeThreshold;
        eventManager2._honorIncreased += HonorPositiveThreshold;
        eventManager2._rewardEvent += Reward;
        eventManager2.NpcDied += becomeAgressive;
        playerInputHandler = FindFirstObjectByType<PlayerInputHandler>();
        enemy = GetComponent<Enemy>();
        target = FindFirstObjectByType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();
        dialogGood.resetDialog();
        dialogBad.resetDialog();
        dialogBad.index = 0;
        dialogGood.index = 0;
        CurrentSo = dialogGood;
        dialogassets = CurrentSo.dialog;
        text.text = CurrentSo.currentDialog;
        text.enabled = false;

        if (enemy && agent != null)
        {
            enemy.Speed = 0;
            agent.speed = 0;
            enemy.isRanged = false;
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
