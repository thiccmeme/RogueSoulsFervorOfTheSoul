using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField]
    protected int bulletDamage;
    [SerializeField]
    protected PlayerWeapon weapon;
    [SerializeField]
    protected float _maxTravelDistance;
    protected PlayerController _controller;
    public float bulletLifetime;
    [SerializeField]
    private BulletType bulletType;

    private EventManager2 eventManager2;

    public bool hasHit = false;

    public Renderer renderer;
    public int queueOrder = 5000;
    [SerializeField]private GameObject Blood;
    
    
    
    

    public virtual void OnEnable()
    {
        _controller = FindObjectOfType<PlayerController>();
        Invoke("Destroy", bulletLifetime);
    }

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        eventManager2 = FindFirstObjectByType<EventManager2>();
        renderer.material.renderQueue = queueOrder;
    }

    public virtual void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, _controller.transform.position) >= _maxTravelDistance)
        {
            Destroy();
        }
        if (transform.position.z != 0)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    public virtual void Destroy()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<NpcHitBox>() && bulletType == BulletType._Player)
        {
            if (!hasHit)
            {
                var enemyToHit = other.gameObject.GetComponentInParent<EntityStats>();
                Debug.Log(bulletDamage);
                enemyToHit.TakeDamage(bulletDamage);
                var blood = Instantiate(Blood, enemyToHit.transform);

            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player")&& bulletType == BulletType._Enemy)
        {
            eventManager2.RunDamagedEvent();
            if (!hasHit)
            {
                hasHit = true;
                PlayerStats enemyToHit = other.gameObject.GetComponent<PlayerStats>();
                enemyToHit.TakeDamage(bulletDamage);
            }
            Destroy(this.gameObject);
        }
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (bulletType == BulletType._Enemy && tag != "BossWeapon")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayerAssignWeapon(PlayerWeapon weaponToAssign)
    {
        weapon = weaponToAssign;
        bulletDamage = weapon.AssignDamage();
        bulletLifetime = weapon.bulletLifetime;
    }
}

public enum BulletType
{
    _Player,_Enemy,_Explosive
}



