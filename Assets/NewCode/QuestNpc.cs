using UnityEngine;

public class QuestNpc : NpcSystem
{

    protected EventManager2 eventManager2;
    private void QuestComplete()
    {
        
    }

    private void Start()
    {
        eventManager2 = FindFirstObjectByType<EventManager2>();
        eventManager2.NpcShot += QuestComplete;
    }
    
    
}
