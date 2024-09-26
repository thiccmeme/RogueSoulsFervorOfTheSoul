using UnityEngine;

public class QuestProgressReward : MonoBehaviour
{

    private EventManager2 eventManager2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventManager2 = FindFirstObjectByType<EventManager2>();
        eventManager2.RunEvent();
        Debug.Log("Questreward");
        //Destroy(this.gameObject);
    }


}
