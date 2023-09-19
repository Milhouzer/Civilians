using UnityEngine;

namespace Milhouzer.Character
{
    public class FishingState : CharacterState, IAnimatedState
    {
        public override bool AllowMovement => false;
        public override bool AllowCharacterRotation => false;

        private Animator animator;
        public Animator CharacterAnimator { get => animator; }
        private string animationState;
        public string AnimationState { get => animationState; }

        public FishingState(ICharacter character) : base(character, "Fishing") 
        {
            animator = character.CharacterAnimator;
            animationState = "Fishing";
        }

        protected override void OnEnterState()
        {
            animator.SetBool(animationState, true);
        }

        protected override void OnUpdateState()
        {
            float r = Random.Range(0,100f);

            if(r <= timer)
            {
                CatchFish();
            }
        }

        protected override void OnExitState()
        {
            animator.SetBool(animationState, false);
        }

        private void CatchFish()
        {
            Debug.Log("Fish catched! ");
        }
    }
}

