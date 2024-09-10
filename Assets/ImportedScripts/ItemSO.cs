using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "SOs/UI/Items/ItemSO", order=1)]
public class ItemSO : ScriptableObject
{
    public Sprite _sprite;

    public Material _material;

    public EquipableItem equipableItem;

    public GameObject inventoryButton;
    
    [field: SerializeField] public string ItemName { get; private set; }
    
    public ItemType itemType;
    [field: SerializeField, TextArea] public string ItemDescription { get; private set; }
    
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

public enum ItemType
{
    Key, Weapon, Useless
}
