using UnityEngine;

public class BackwardsPressurePlate : MonoBehaviour
{
    
    [SerializeField]private TargetDoor door;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteOg;
    [SerializeField] private Sprite spriteSwitched;
    public bool isTriggered;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isTriggered)
        {
            door.CheckPlates(this);
            spriteRenderer.sprite = spriteSwitched;
        }
        isTriggered = true;
    }
}
