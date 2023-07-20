using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.Interfaces
{
    public interface IInteractable
    {
        bool IsInteracting { get; }

        void Interact() { }
        void StopInteract() { }
    }
}
