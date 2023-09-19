using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.Utility.Interfaces
{
    public interface IInteractable
    {
        float InteractionRange { get; }
        bool CanInteract { get; }
        bool IsInteracting { get; }

        Vector3 GetPosition();
        void OnEnterInteractionRange() { }
        void OnExitInteractionRange() { }
        void Interact(GameObject interactor) { }
        void StopInteract() { }
    }
}
