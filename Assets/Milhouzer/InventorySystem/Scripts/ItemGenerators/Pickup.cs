using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Utility;
using Milhouzer.Character;

namespace Milhouzer.InventorySystem
{
    public class Pickup : InteractableBase
    {
        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);
            Milhouzer.Character.CharacterController controller = interactor.GetComponent<Milhouzer.Character.CharacterController>();
            controller.ChangeState(new PickupState(controller));
        }
    }
}
