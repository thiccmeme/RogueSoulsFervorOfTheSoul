using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class PlayerWeapon : MonoBehaviour
{
    #region global Variables
    //weapon basics

    [SerializeField]
    public float fireRate;
    [SerializeField]
    public float bulletLifetime;
    [field: SerializeField]
    public int MaxAmmo { get; private set; }
    [SerializeField]
    public float bulletCount;
    [SerializeField]
    public float reloadTime;
    [SerializeField]
    public Camera cam;
    [SerializeField]
	public Transform firePoint;
	[SerializeField]
	public PlayerProjectile bulletPrefab;
    [SerializeField] public float bulletForce;
    [SerializeField]
    public float minSpread;
    [SerializeField]
    public float maxSpread;
    [SerializeField]
    public int damage;
    public ItemSO _gun;
    public PlayerInputHandler _inputHandler;
    public PlayerController playerController { get; private set; }
    public float timeToNextFire;
    public EventManager2 _EventManager2;
    bool shoot;


    //end of editable variables within the inspector

    public int CurrentAmmo;
    public bool isReloading = false;
#endregion

#region first load

    private void OnEnable()
    {

        playerController = GetComponentInParent<PlayerController>();
        if (playerController)
        {
            _inputHandler = GetComponentInParent<PlayerInputHandler>();
            _inputHandler.UpdatePlayerWeaponReference();
        }
    }

    private void Start()
    {
        damage = _gun.damage;
        minSpread = _gun.minspread;
        maxSpread = _gun.maxspread;
        MaxAmmo = _gun.maxAmmo;
        bulletCount = _gun.bulletCount;
        bulletForce = _gun.bulletForce;
        fireRate = _gun.fireRate;
        reloadTime = _gun.reloadTime;
        bulletLifetime = _gun.bulletLifeTime;
        bulletPrefab = _gun.bullet;
        timeToNextFire = _gun.timeToNextFire;
        CurrentAmmo = MaxAmmo;


    }

    public void OnShoot()
    {
        if (shoot && CurrentAmmo!= 0)
        {
            Debug.Log("Shoot");
            Shoot();
        }
        else if (CurrentAmmo == 0)
        {
            Reload();
        }
    }
    
    void DamageFlash()
    {
        
    }
    

    #endregion


    #region Shoot

    public virtual void Shoot(Vector2 additionalVelocity = new Vector2())
    {
        if (GetComponentInParent<PlayerController>())
        {
            if (Time.time >= timeToNextFire && !isReloading)
            {
                timeToNextFire = Time.time + 1.0f / fireRate;// sets the time for the next bullet to be able to be fired

                CurrentAmmo--;

                Quaternion defaultSpreadAngle = firePoint.localRotation;
                float spread = Random.Range(minSpread, maxSpread);
                firePoint.transform.Rotate(new Vector3(0, 0, 1), -spread / 2f);
                for (int i = 0; i < bulletCount; i++)
                {
                    float angle = (float)spread / (float)(bulletCount);

                    firePoint.transform.Rotate(new Vector3(0, 0, 1), angle);

                    PlayerProjectile bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.identity);
                    bullet.PlayerAssignWeapon(this);
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation;
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.linearVelocity = Vector2.zero;
                    rb?.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse); //impulse force represents impact 
                }

                firePoint.localRotation = defaultSpreadAngle;
            }
        }
        else if (GetComponentInParent<Enemy>())
        {
            if (Time.time >= timeToNextFire && !isReloading)
            {
                timeToNextFire = Time.time + 1.0f / fireRate;// sets the time for the next bullet to be able to be fired

                CurrentAmmo--;

                Quaternion defaultSpreadAngle = firePoint.localRotation;
                float spread = Random.Range(minSpread, maxSpread);
                firePoint.transform.Rotate(new Vector3(0, 0, 1), -spread / 2f);
                for (int i = 0; i < bulletCount; i++)
                {
                    float angle = (float)spread / (float)(bulletCount);

                    firePoint.transform.Rotate(new Vector3(0, 0, 1), angle);

                    PlayerProjectile bullet = Instantiate(bulletPrefab,new Vector3(transform.position.x, transform.position.y, 0),Quaternion.identity);
                    bulletPrefab.PlayerAssignWeapon(this);
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation;
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    if(rb != null)
                    {
                        rb.linearVelocity = Vector2.zero;
                        rb?.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);//impulse force represents impact 
                    }
                }

                firePoint.localRotation = defaultSpreadAngle;
            }
        }

            
            
    }

    #endregion
    #region Reload
    public void Reload()
    {
        if(CurrentAmmo != MaxAmmo)
        {
            isReloading = true;

            if(GetComponentInParent<PlayerController>())
            {
                //_uiHandler.EnableReloadingText(reloadTime);
            }
            Invoke("FinishReload", reloadTime); // we do an invoke so we can add a delay to the reload time, rather than a regular function call
        }
    }
    
    public void EnableShootInput()//virtual function can be overridden 
    {
        shoot = true;
    }

    public void DisableShootInput()
    {
        shoot = false;
    }


    public virtual void FinishReload()
    {
        CurrentAmmo = MaxAmmo;
        isReloading = false;
    }
    #endregion
    #region Damage
    public int AssignDamage( )
    {
        return damage;
    }
}
#endregion
