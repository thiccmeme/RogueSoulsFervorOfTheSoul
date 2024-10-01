using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDoor : Door
{

    [SerializeField] private NpcSystem npc;

    [SerializeField]private BackwardsPressurePlate[] platesToTrigger;
    private int platesTriggered;
    int targetsHit = 0;
    [SerializeField]
    float secondsToClose =5.0f;

    public void CheckPlates(BackwardsPressurePlate plates)
    {
            Debug.Log("triggered");
            platesTriggered++;

        if (platesTriggered == platesToTrigger.Length)
        {
            Debug.Log("DoorOpen");
            base.UnlockDoor();
            base.OpenDoor();
            if (npc != null)
            {
                Debug.Log("agressive");
                npc.becomeAgressive();
            }
        }
    }

    public void RemovePlates(BackwardsPressurePlate plates)
    {
        if (!plates.isTriggered)
        {
            platesTriggered--;
        }

        if (platesTriggered != platesToTrigger.Length)
        {
            base.CloseDoor();
        }
    }

    private void FixedUpdate()
    {

    }



}
