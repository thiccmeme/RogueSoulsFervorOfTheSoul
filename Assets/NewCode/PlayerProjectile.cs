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

    public bool hasHit = false;

    public virtual void OnEnable()
    {
        _controller = FindObjectOfType<PlayerController>();
        Invoke("Destroy", bulletLifetime);
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
        if(other.gameObject.CompareTag("Enemy") && bulletType == BulletType._Player)
        {
            if (!hasHit)
            {
                hasHit = true;
                var enemyToHit = other.gameObject.GetComponent<EntityStats>();
                Debug.Log(bulletDamage);
                enemyToHit.TakeDamage(bulletDamage);
            }

            Destroy(this.gameObject);
        }
        /*else if (other.gameObject.CompareTag("Player")&& bulletType == BulletType._Enemy)
        {
            PlayerStats enemyToHit = other.gameObject.GetComponent<PlayerStats>();
            enemyToHit.TakeDamage(bulletDamage);
        }*/
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



