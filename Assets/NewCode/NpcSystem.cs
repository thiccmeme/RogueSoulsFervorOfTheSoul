using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Random = System.Random;

public class NpcSystem : MonoBehaviour
{

    [SerializeField] private TMP_Text text;

    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] protected DialogSo dialogGood;
    [SerializeField] protected DialogSo dialogBad;
    [SerializeField] protected DialogSo dialogNeutral;
    [SerializeField] protected string[] dialogassets;
    [SerializeField] protected DialogSo CurrentSo;
    [SerializeField] protected bool triggered = false;
    [SerializeField] protected int PositiveTreshHold;
    [SerializeField] protected int NegativeTreshHold;
    [SerializeField] protected int currentHonor;
    [SerializeField] protected PlayerInputHandler playerInputHandler;
    [SerializeField] protected GameObject goodReward;
    [SerializeField] protected GameObject badReward;
    [SerializeField] protected GameObject neutralReward;
    [SerializeField] protected bool finished = false;
    protected bool targetInRange;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Transform target;
    [SerializeField] protected float detectionRadius = 12;
    public int index = 0;
    [SerializeField] protected PlayerWeapon enemyGun;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected TMP_FontAsset font;
    [SerializeField] protected NpcType type;
    protected bool hasDecreased = false;
    [SerializeField] protected GameObject deathItem;

    private EventManager2 eventManager2;
    
    public void OnTalk()// take player input to run event
    {
        eventManager2.RunNextEvent();
    }

    public void Interact()// call the index function
    {
        IndexText();
    }

    private void OnTriggerEnter2D(Collider2D other)// show text
    {
        if (other.CompareTag("Player") && triggered == false )
        {
            eventManager2._NextEvent += Interact;
            playerInputHandler.UpdateNpcSystemReference(this);
            
            triggered = true;
            text.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)// stop showing text
    {
        if (other.CompareTag("Player"))
        {
            eventManager2._NextEvent -= Interact;
            text.enabled = false;
            triggered = false;
        }
        
    }

    private void becomeAgressive()// if npc "sees" player kill npc turn agressive regardless of honour
    {
        Debug.Log("agressive");
        if (targetInRange && agent != null)
        {
            type = NpcType.Aggressive;
            enemy.Speed = 3;
                agent.speed = 3;
            enemy.isRanged = true;
            HonorNegativeThreshold();
            eventManager2._honorIncreased -= HonorPositiveThreshold;
            eventManager2._honorDecreased -= HonorNegativeThreshold;
            eventManager2._honorIncreased -= HonorNeutralThreshold;
            eventManager2._honorDecreased -= HonorNeutralThreshold;
        }
    }

    public void LootDrop()// drop loot on death
    {
        if (deathItem != null)
        {
            var loot = Instantiate(deathItem, new Vector3(transform.localPosition.x, transform.localPosition.y,transform.localPosition.z), quaternion.Euler(0,0,0));
            loot.transform.localRotation = Quaternion.Euler(0,0,0);
            loot.transform.localPosition = this.transform.localPosition;
        }
    }

    private void IndexText()// go to next piece of text
    {

        Debug.Log(dialogassets.Length);
        if (index >= 0 && index < dialogassets.Length && finished == false)
        {
            index++;
            CurrentSo.IncreaseIndex();
            text.text = CurrentSo.currentDialog;
        }
        else
        {
            if (finished)
            {
                return;
            }
            else if (type == NpcType.Questing || type == NpcType.Neutral)
            {
                Reward();
            }
            finished = true;
        }

    }

    public void HonorNegativeThreshold()
    {
        index = 0;
        currentHonor--;
        Debug.Log(currentHonor);
        if (currentHonor <= NegativeTreshHold && dialogBad != null)
        {
            dialogBad.resetDialog();
            CurrentSo = dialogBad;
            text.text = CurrentSo.currentDialog;
            text.color = Color.red;
            finished = false;
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

        if (currentHonor == 0 && neutralReward != null)
        {
            var good = Instantiate(neutralReward, new Vector3(transform.localPosition.x, transform.localPosition.y,transform.localPosition.z), quaternion.Euler(0,0,0));
            good.transform.localRotation = Quaternion.Euler(0,0,0);
            good.transform.localPosition = this.transform.localPosition;
            Debug.Log("neutral");
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
        index = 0;
        currentHonor++;
        Debug.Log(currentHonor);
        if (currentHonor >= PositiveTreshHold && dialogGood != null)
        {
            dialogGood.resetDialog();
            CurrentSo = dialogGood;
            text.text = CurrentSo.currentDialog;
            text.color = Color.white;
            finished = false;
        }
    }

    public void HonorNeutralThreshold()
    {
        index = 0;
        if (currentHonor == 0 && dialogNeutral != null)
        {
            
            dialogNeutral.resetDialog();
            Debug.Log(dialogNeutral.index);
            CurrentSo = dialogNeutral;
            text.text = CurrentSo.currentDialog;
            text.color = Color.black;
            finished = false;
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

    public void DecreaseHonor()// only decrease once per npc shot who is non aggressive 
    {
        if (hasDecreased == false) 
        {
            currentHonor--;
            Debug.Log("decrease");
            hasDecreased = true;
        }
    }

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        playerInputHandler = FindFirstObjectByType<PlayerInputHandler>();
        enemy = GetComponent<Enemy>();
        target = FindFirstObjectByType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();
        if (dialogGood != null)
        {
            dialogGood.resetDialog();
            dialogGood.index = 0;
        }

        if (dialogBad != null)
        {
            dialogBad.resetDialog();
            dialogBad.index = 0;
        }

        if (dialogNeutral != null)
        {
            dialogNeutral.resetDialog();
            dialogNeutral.index = 0;
        }
        type = enemy.type;
        if (type == NpcType.Neutral || type == NpcType.Passive || type == NpcType.Questing)
        {
            CurrentSo = dialogNeutral;
            eventManager2._honorDecreased += HonorNegativeThreshold;
            eventManager2._honorIncreased += HonorPositiveThreshold;
            eventManager2._honorDecreased += HonorNeutralThreshold;
            eventManager2._honorIncreased += HonorNeutralThreshold;
            eventManager2.NpcShot += DecreaseHonor;
        }
        
        if (type == NpcType.Neutral)
        {
            eventManager2.NpcShot += becomeAgressive;
            if (enemy && agent != null)
            {
                enemy.Speed = 0;
                agent.speed = 0;
                enemy.isRanged = false;
            }
        }

        if (type == NpcType.Aggressive || type == NpcType.Boss)
        {
            CurrentSo = dialogBad;
            text.color = Color.red;
        }
        
        
        dialogassets = CurrentSo.dialog;
        text.text = CurrentSo.currentDialog;
        text.enabled = false;
        text.color = Color.black;
        
    }
    
}

public enum NpcType
{
    Questing,Boss,Passive,Aggressive,Neutral
}
