using UnityEngine;

namespace Milhouzer.Character
{
    public class PickupState : CharacterState, IAnimatedState
    {
        public override bool AllowMovement => false;
        public override bool AllowCharacterRotation => false;
        public override bool AllowCameraRotation => false;

        private Animator animator;
        public Animator CharacterAnimator { get => animator; }
        private string animationState;
        public string AnimationState { get => animationState; }

        public PickupState(ICharacter character) : base(character, "Pickup") 
        {
            animator = character.CharacterAnimator;
            animationState = "Pickup";
        }

        protected override void OnEnterState()
        {
            animator.SetTrigger(animationState);
        }

        protected override void OnUpdateState()
        {
            if(timer > 3.1f)
            {
                character.ChangeState(new IdleState(character));
            }
        }

        protected override void OnExitState()
        {

        }
    }
}

