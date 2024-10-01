using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDoor : Door
{
    [SerializeField]
    private TargetSwitch[] targetsToHit;

    [SerializeField] private NpcSystem npc;

    [SerializeField]private BackwardsPressurePlate[] platesToTrigger;
    private int platesTriggered;
    int targetsHit = 0;
    [SerializeField]
    float secondsToClose =5.0f;

    public void CheckTargets(TargetSwitch targetToCheck)
    {

        if (targetToCheck.IsTriggered)
        {
            targetsHit++;
        }
        if (targetsHit == targetsToHit.Length)
        {
            base.OpenDoor();
            Invoke("CloseAfterDuration", secondsToClose);
        }

    }

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
    public void CloseAfterDuration()
    {
        base.CloseDoor();
        foreach (TargetSwitch target in targetsToHit)
        {
            if(target.IsTriggered)
            {
                target.ResetSwitch();
            }
        }
        targetsHit = 0;
    }
    public void DecreaseIndex()
    {
        targetsHit--;
    }



}
