using System;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]private Door door;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteOg;
    [SerializeField] private Sprite spriteSwitched;

    private void OnTriggerEnter2D(Collider2D other)
    {
        door.UnlockDoor();
        door.OpenDoor();
        spriteRenderer.sprite = spriteSwitched;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
            door.CloseDoor();
            spriteRenderer.sprite = spriteOg;
    }
    
    
}
