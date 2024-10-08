using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerController playerController;
    private UIHandler uiHandler;
    public PlayerWeapon playerWeapon;
    public EquipableItem _Equipable;
    public NpcSystem npcSystem;

    private CharacterInput characterInput;

    private void OnEnable()
    {
        playerController = GetComponent<PlayerController>();
        uiHandler = FindObjectOfType<UIHandler>();
        playerWeapon = GetComponent<PlayerWeapon>();
        _Equipable = FindObjectOfType<EquipableItem>();
        npcSystem = FindFirstObjectByType<NpcSystem>();
        if(characterInput == null)
        {
            //if(!uiHandler.IsPaused)
            {
                characterInput = new CharacterInput();
                characterInput.CharacterMovement.Movement.performed += i => playerController?.HandleMovementInput(i.ReadValue<Vector2>());
                characterInput.CharacterMovement.AimMouse.performed += i => playerController?.HandleAimMouseInput(i.ReadValue<Vector2>());
                    characterInput.CharacterActions.Attack.started += i => playerWeapon?.OnShoot();
                characterInput.CharacterActions.DodgeRoll.started += i => playerController?.HandleDodgeRollInput();
                characterInput.CharacterActions.Interact.started += i => npcSystem?.OnTalk();

                
                characterInput.CharacterActions.Unequip.performed += i => _Equipable.OnUnequip();
                
            }
            
            characterInput.CharacterActions.PauseMenu.started += i => uiHandler?.TogglePauseMenu();
        }

        characterInput.Enable();
    }
    
    public void UpdateItemRefernce()
    {
        _Equipable = GetComponentInChildren<EquipableItem>();
    }

    public void UpdatePlayerWeaponReference()
    {
        playerWeapon = GetComponentInChildren<PlayerWeapon>();
    }
    

    public void UpdateNpcSystemReference(NpcSystem npcsystem)
    {
        npcSystem = npcsystem;
    }
    
}
