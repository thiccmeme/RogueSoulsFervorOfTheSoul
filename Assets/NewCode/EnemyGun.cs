using UnityEngine;

public class EnemyGun: PlayerWeapon
{
    
    public int damage;
    public float fireRate;
    public float minspread, maxspread;
    public Transform firePoint;
    public int bulletCount;
    public float bulletLifeTime;
    public int maxAmmo;
    public float bulletForce;
    public float reloadTime;
    [SerializeField]
    private PlayerProjectile bullet;
    public float timeToNextFire;
    public int CurrentAmmo;
    private bool isReloading = false;
    private Rigidbody2D rb;
    public ItemSO _itemSo;

    void Start()
    {
        timeToNextFire = _itemSo.timeToNextFire;
        bullet = _itemSo.bullet;
        reloadTime = _itemSo.reloadTime;
        bulletForce = _itemSo.bulletForce;
        maxAmmo = _itemSo.maxAmmo;
        bulletLifeTime = _itemSo.bulletLifeTime;
        bulletCount = _itemSo.bulletCount;
        minspread = _itemSo.minspread;
        maxspread = _itemSo.maxspread;
        fireRate = _itemSo.fireRate;
        damage = _itemSo.damage;
        CurrentAmmo = maxAmmo;
    }

    public void FixedUpdate()
    {
        if (CurrentAmmo == 0 && !isReloading)
        {
            Reload();
        }
    }

    public void ShootGun()
    {
        
    }
    
    public void Reload()
    {
        if (CurrentAmmo != maxAmmo)
        {
            isReloading = true;
            Invoke("FinishReload", reloadTime);
        }
    }

    public void FinishReload()
    {
        isReloading = false;
        CurrentAmmo = maxAmmo;
    }
}
