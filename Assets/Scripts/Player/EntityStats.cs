using Unity.Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    #region GlobalVariables
    [field: SerializeField]
    public int Health { get; private set; }

    [SerializeField]
    protected int _maxHealth;
    public int AmountOfHearts { get; private set; }

    [field: SerializeField]
    public int Damage { get; private set; }

    public float Speed;

    [field: SerializeField]
    public float TimeToAttack { get; private set; }

    [SerializeField]
    HeartDisplayHandler _heartDisplayHandler;

    [SerializeField]
    protected GameManager _gameManager;

    public EventManager2 eventManager2;

    Heart heart;
    [SerializeField] public NpcType type;

    #endregion

    protected virtual void Awake()
    {
        _heartDisplayHandler = GetComponentInChildren<HeartDisplayHandler>();
        _gameManager = FindObjectOfType<GameManager>();
        UpdateHeartAmount();
        Health = _maxHealth;
        eventManager2 = FindFirstObjectByType<EventManager2>();
    }

    #region Health
    public virtual void UpdateHeartAmount()
    {
        AmountOfHearts = _maxHealth / 4;
    }
    public virtual void TakeDamage(int damage)
    {
        IncrementHealth(-damage);
        
        if (Health <= 0 && type == NpcType.Boss)
        {
            eventManager2.RunHonorincreasedEvent();
            Destroy(this.gameObject);
        }

        if (Health <= 0 && type == NpcType.Aggressive)
        {
            Destroy(this.gameObject);
        }

        if (Health <= 0 && type == NpcType.Passive)
        {
            eventManager2.RunHonorDecreasedEvent();
            Destroy(this.gameObject);
            
        }

        if (type == NpcType.Passive || type == NpcType.Neutral)
        {
            eventManager2.RunNpcShotEvent();
        }
        
        
    } 

    public void IncreaseHealth(int increaseAmount)
    {
        _heartDisplayHandler.AddOneHeart();
        _maxHealth += 4;
        IncrementHealth(increaseAmount);
        UpdateHeartAmount();
        if (_heartDisplayHandler != null)
        {
            _heartDisplayHandler.CheckHeartQuarters();
        }
    }

    public virtual void IncrementHealth(int incrementAmount)
    {
        Health += incrementAmount;
        Health = Mathf.Clamp (Health, 0 , _maxHealth);
        if (_heartDisplayHandler != null)
        {
            _heartDisplayHandler.CheckHeartQuarters();
        }
    }
    

    public bool AtFullHealth()
    {
        return Health == _maxHealth;
    }

    
    #endregion
}
