using System;
using UnityEngine;

public class DoorOpenReward : MonoBehaviour
{

    public Door door;

    public void Start()
    {
        door.OpenDoor();
        door.UnlockDoor();
        Destroy(this.gameObject);
    }
}
