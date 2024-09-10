using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class Items : ScriptableObject
{

}

public enum ItemTypes
{
    Key, Weapon, Useless, Heart
}
