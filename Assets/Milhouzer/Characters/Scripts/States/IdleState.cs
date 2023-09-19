using UnityEngine;

namespace Milhouzer.Character
{
    public class IdleState : CharacterState
    {
        public IdleState(ICharacter character) : base(character, "Idle") { }

        protected override void OnEnterState()
        {
            
        }

        protected override void OnUpdateState()
        {

        }

        protected override void OnExitState()
        {

        }
    }
}
