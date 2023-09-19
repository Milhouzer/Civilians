using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Utility;

namespace Milhouzer.Character
{
    public class Pickup : InteractableBase
    {
        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);
            ICharacter character = interactor.GetComponent<ICharacter>();
            character.ChangeState(new PickupState(character));
        }
    }
}
