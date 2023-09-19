using Milhouzer.Utility.Interfaces;
using Milhouzer.Utility;
using UnityEngine;

namespace Milhouzer.Character
{
    public class CharacterController : MonoBehaviour, ICharacter
    {
        [SerializeField]
        private Animator animator;
        public Animator CharacterAnimator => animator;

        [SerializeField]
        private CharacterState currentState;
        public CharacterState CurrentState => currentState;

        private void Start()
        {
            // Set the initial state (e.g., IdleState) when the character starts.
            ChangeState(new IdleState(this));
        }

        private void Update() 
        {
            if(currentState != null)
            {
                currentState.UpdateState();
            }
        }

        public bool ChangeState(CharacterState newState)
        {
            if(!StateUtility.CanChangeState(currentState, newState))
                return false;

            if (currentState != null)
            {
                currentState.ExitState();
            }

            currentState = newState;
            currentState.EnterState();
            return true;
        }

        public void Interact()
        {
            IInteractable target = InteractableBase.GetPreferredInteractable();
            if(target != null)
            {
                Debug.Log("Interact with " + target);
                Interact(target);
            }
        }

        public void Interact(IInteractable target)
        {
            target.Interact(gameObject);
        }
    }
}
