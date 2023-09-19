using UnityEngine;

namespace Milhouzer.Character
{
    public abstract class CharacterState
    {
        protected ICharacter character;
        protected string tag;
        public string Tag => tag;

        public virtual bool AllowMovement => true;
        public virtual bool AllowCameraRotation => true;
        public virtual bool AllowCharacterRotation => true;

        protected float timer;
        public float Timer => timer;

        public CharacterState(ICharacter character, string tag)
        {
            this.character = character;
            this.tag = tag;
        }
        
        public void EnterState()
        {
            timer = 0f;
            OnEnterState();
        }

        protected abstract void OnEnterState();
        

        public void UpdateState()
        {
            timer += Time.deltaTime;
            OnUpdateState();
        }

        protected abstract void OnUpdateState();

        public void ExitState()
        {
            OnExitState();
        }

        protected abstract void OnExitState();


    }

    public interface IAnimatedState
    {
        Animator CharacterAnimator { get; }
        string AnimationState { get; }
    }
}
