using System;
using UnityEngine;

public class GunSo : ItemSO
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
    public PlayerProjectile bullet;

}
