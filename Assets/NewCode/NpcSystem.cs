using System;
using System.Collections.Generic;
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

    [SerializeField] public DialogSo dialogGood;
    [SerializeField] public DialogSo dialogBad;
    [SerializeField] protected DialogSo dialogNeutral;
    [SerializeField] protected DialogSo questDialog;
    [SerializeField] protected DialogSo alternateQuestDialog;
    [SerializeField] protected string[] dialogassets;
    [SerializeField] public DialogSo CurrentSo;
    [SerializeField] protected bool triggered = false;
    [SerializeField] protected int PositiveTreshHold;
    [SerializeField] protected int NegativeTreshHold;
    [SerializeField] protected int currentHonor;
    [SerializeField] protected PlayerInputHandler playerInputHandler;
    [SerializeField] protected GameObject reward;
    [SerializeField] protected bool finished = false;
    protected bool targetInRange;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Transform target;
    [SerializeField] protected float detectionRadius = 12;
    public int index = 1;
    [SerializeField] protected PlayerWeapon enemyGun;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected TMP_FontAsset font;
    [SerializeField] protected NpcType type;
    protected bool hasDecreased = false; 
    public GameObject deathItem;
    private PlayerController player;
    private bool questComplete;
    [SerializeField]private bool QuestBegun;
    [SerializeField]private bool canReward;
    public List<Enemy> enemies;

    private EventManager2 eventManager2;
    
    public void OnTalk()// take player input to run event
    {
        eventManager2.RunNextEvent();
    }
    
    public void NotifiyQuestNpc(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count <= 0)
        {
            ChangeQuestDialog();
        }
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

        if (other.GetComponent<PlayerProjectile>() && type == NpcType.Questing)
        {
            becomeAgressive();
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

    public void ChangeQuestDialog()// run on event that can be given on enemy death or quest completion as reward, only run if npc has been talked to before to prevent dialog from changing otherwise
    {
        if (QuestBegun)
        {
            index = 0;
            finished = false;
            questDialog.ResetDialog();
            CurrentSo = questDialog;
            dialogassets = CurrentSo.dialog;
            text.text = CurrentSo.currentDialog;
        }
        else
        {
            Debug.Log("alternate");
            index = 0;
            finished = false;
            alternateQuestDialog.ResetDialog();
            CurrentSo = alternateQuestDialog;
            dialogassets = CurrentSo.dialog;
            text.text = CurrentSo.currentDialog;
        }
    }

    public void AlternateQuestDialog()
    {

    }

    private void becomeAgressive()// if npc "sees" player kill npc turn agressive regardless of honour
    {
        //Debug.Log("agressive");
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
            var loot = Instantiate(deathItem, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            //loot.transform.localPosition = player.transform.localPosition;

        }
    }

    private void IndexText()// go to next piece of text
    {
        if ( index < dialogassets.Length)
        {
            index++;
            CurrentSo.IncreaseIndex();
            text.text = CurrentSo.currentDialog;
            Debug.Log(index);
            Debug.Log(dialogassets.Length);
        }
        else
        {
            Debug.Log("fuckme");
            if (type == NpcType.Questing)
            {
                
                QuestBegun = true;
                if (canReward)
                {
                    QuestBegun = true;
                    ChangeQuestDialog();
                }
                if (CurrentSo == questDialog || CurrentSo == alternateQuestDialog)
                {
                    Reward();
                }
                
            }
            
        }
    }

    public void HonorNegativeThreshold()
    {
        index = 0;
        currentHonor--;
        //Debug.Log(currentHonor);
        if (currentHonor <= NegativeTreshHold && dialogBad != null)
        {
            dialogBad.ResetDialog();
            CurrentSo = dialogBad;
            text.text = CurrentSo.currentDialog;
            text.color = Color.red;
            finished = false;
        }
    }

    public void Reward()
    {
        Debug.Log("good");
        if ( reward != null && questComplete == false)
        {
            var good = Instantiate(reward, transform);
            questComplete = true;

        }
    }
    
    public void HonorPositiveThreshold()
    {
        index = 0;
        currentHonor++;
        //Debug.Log(currentHonor);
        if (currentHonor >= PositiveTreshHold && dialogGood != null)
        {
            dialogGood.ResetDialog();
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
            
            dialogNeutral.ResetDialog();
            //Debug.Log(dialogNeutral.index);
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
            //Debug.Log("decrease");
            hasDecreased = true;
        }
    }
    

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        text = GetComponentInChildren<TMP_Text>();
        playerInputHandler = FindFirstObjectByType<PlayerInputHandler>();
        enemy = GetComponent<Enemy>();
        target = FindFirstObjectByType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();
        if (dialogGood != null)
        {
            dialogGood.ResetDialog();
            dialogGood.index = 0;
        }

        if (dialogBad != null)
        {
            dialogBad.ResetDialog();
            dialogBad.index = 0;
        }

        if (dialogNeutral != null)
        {
            dialogNeutral.ResetDialog();
            dialogNeutral.index = 0;
        }

        if (questDialog != null)
        {
            questDialog.ResetDialog();
            questDialog.index = 0;
        }

        if (alternateQuestDialog != null)
        {
            alternateQuestDialog.ResetDialog();
            alternateQuestDialog.index = 0;
        }
        type = enemy.type;
        if (type == NpcType.Neutral || type == NpcType.Passive)
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

        if (type == NpcType.Questing)
        {
            CurrentSo = dialogNeutral;
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
