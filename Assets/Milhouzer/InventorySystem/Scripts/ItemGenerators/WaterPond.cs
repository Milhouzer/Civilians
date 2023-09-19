using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Utility;
using Milhouzer.Character;

namespace Milhouzer.InventorySystem
{
    public class WaterPond : InteractableBase
    {
        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);
            ICharacter character = interactor.GetComponent<ICharacter>();
            // Milhouzer.Character.CharacterController controller = interactor.GetComponent<Milhouzer.Character.CharacterController>();
            character.ChangeState(new FishingState(character));
        }
    }
}
