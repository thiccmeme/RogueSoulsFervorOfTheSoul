using UnityEngine;

public class HonorDecrease : MonoBehaviour
{
    private EventManager2 eventManager2;

    private void Start()
    {
        eventManager2 = FindFirstObjectByType<EventManager2>();
        eventManager2.RunHonorDecreasedEvent();
        Invoke("Destroy", 1.0f);
    }
    
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
