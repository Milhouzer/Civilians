using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.Character
{
    public interface ICharacter
    {
        
        public Animator CharacterAnimator { get; }
        public CharacterState CurrentState { get; }

        bool ChangeState(CharacterState newState);
        void Interact();
    }
}
