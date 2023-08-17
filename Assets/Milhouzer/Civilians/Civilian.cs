using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Interfaces;

namespace Milhouzer.Civilian
{
    public class Civilian : MonoBehaviour, IInteractable
    {
        private bool isInteracting;
        public bool IsInteracting { get => isInteracting; }

        public void Interact()
        {
            isInteracting = true;
        }

        public void StopInteract()
        {

        }
    }
}
