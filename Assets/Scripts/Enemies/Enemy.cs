using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : EntityStats
{
    #region Global Variables

    [SerializeField] public Transform target;
    protected NavMeshAgent _agent;
    [SerializeField]
    public bool isRanged = true;
    [SerializeField]
    public Transform gunLocation;
    [SerializeField]
    protected float _rotateSpeed = 100;
    public float _enemyWeaponRotationAngle;
    protected bool targetInRange;
    [SerializeField]
    EnemyDoor enemyDoor;
    private EventManager2 eventManager2;
    public WeaponOffsetHandle _offsetHandle;
    [SerializeField]protected GameObject enemySprite;
    [SerializeField]
    protected ParticleSystem _deathEffect;
    [SerializeField]
    protected float detectionRadius = 12;
    //public ItemSO _itemSo;
    [SerializeField]
    public PlayerWeapon enemyGun;

    #endregion
    

    #region Start   
    protected virtual void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = Speed;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        //enemySprite = GetComponentInChildren<SpriteRenderer>().gameObject;
        _offsetHandle = GetComponentInChildren<WeaponOffsetHandle>();
        eventManager2 = FindFirstObjectByType<EventManager2>();
        target = FindObjectOfType<PlayerController>().transform;
        transform.localRotation = Quaternion.Euler(0,0,0);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (enemyDoor != null && Health <= 0)
        {
            enemyDoor.NotifyEnemyDied(this);
        }
        
        if(_deathEffect && Health <= 0)
        {
            Instantiate(_deathEffect, transform.position, Quaternion.identity);
        }
    }
#endregion
    #region Update
    protected virtual void Update()
    {

        if (isRanged)
        {
            if (target != null && targetInRange)
            {
                enemyGun.Shoot();
                RangedAttack();
            }
        }

        if (transform.position.z != 0)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        bool flipSprite = _agent.velocity.x > 0;

        if(flipSprite)
        {
            enemySprite.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            enemySprite.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    protected virtual void FixedUpdate()
    {
        bool moving = _agent.velocity.x != 0 || _agent.velocity.y != 0;

        if (target != null)
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
 


        if (target != null && targetInRange && _agent.isActiveAndEnabled)
        {
            _agent.SetDestination(target.position);
        }
    }
    
    public virtual void RangedAttack()
    {
        _enemyWeaponRotationAngle = Mathf.Atan2(target.transform.position.y - this.transform.position.y, target.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(_enemyWeaponRotationAngle, Vector3.forward);
        if (_offsetHandle) _offsetHandle.OffsetWeaponPos(_enemyWeaponRotationAngle);
        gunLocation.rotation = Quaternion.Slerp(gunLocation.rotation, rotation, _rotateSpeed * Time.deltaTime);

    }
    
#endregion

    public void StunEnemy()
    {
        _agent.enabled = false;
        Invoke("BreakStun", 4f);
    }

    public void BreakStun()
    {
        _agent.enabled = true;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    
    
}

