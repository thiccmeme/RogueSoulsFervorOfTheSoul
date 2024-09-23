using System;
using UnityEngine;

public class HonorIncrease : MonoBehaviour
{
    private EventManager2 eventManager2;

    private void Start()
    {
        eventManager2 = FindFirstObjectByType<EventManager2>();
        eventManager2.RunHonorincreasedEvent();
        Invoke("Destroy", 1.0f);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
