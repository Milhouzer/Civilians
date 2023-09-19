using System;
using Milhouzer.Utility;
using UnityEngine;

using UnityEngine.InputSystem;

namespace Milhouzer.Character
{
    public class CharacterInput : MonoBehaviour
    {
        [SerializeField] private ICharacter character;
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private CharacterLook characterLook;

        PlayerInput inputActions;

        private bool moving;

        private void Awake() 
        {
            character = GetComponent<ICharacter>();
            if(character == null)
                return;

            inputActions = new PlayerInput();

            // Subscribe to the input action events
            inputActions.Gameplay.Move.started += OnMoveStarted;
            inputActions.Gameplay.Move.performed += OnMovePerformed;
            inputActions.Gameplay.Move.canceled += OnMoveCanceled;

            inputActions.Gameplay.Look.performed += OnLookPerformed;

            inputActions.Gameplay.Interact.performed += OnInteractPerformed;
        }

        private void OnEnable() 
        {
            inputActions.Gameplay.Enable();
        }

        private void OnDisable() 
        {
            inputActions.Gameplay.Disable();
        }
        
        private void Update() 
        {
            Vector2 movement = inputActions.Gameplay.Move.ReadValue<Vector2>();
            characterMovement.Move(movement);
        }

        private void OnMoveStarted(InputAction.CallbackContext context)
        {
            moving = character.ChangeState(new MoveState(character));
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {

        }

        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            if(moving)
            {
                character.ChangeState(new IdleState(character));
                moving = false;
            }
        }

        private void OnLookPerformed(InputAction.CallbackContext context)
        {
            Vector2 look = context.ReadValue<Vector2>();
            characterLook.Look(look);
        }

        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            character.Interact();
        }
    }
}
