using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using Milhouzer.Utility.Interfaces;

namespace Milhouzer.Utility
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        public static List<IInteractable> InRange = new List<IInteractable>();

        public static IInteractable GetPreferredInteractable()
        {
            GameObject interactor = GameObject.FindGameObjectWithTag("Player");
            return InRange.OrderBy(x => Vector3.Distance(interactor.transform.position, x.GetPosition())).FirstOrDefault();
        }

        [SerializeField]
        private float interactionRange;
        public float InteractionRange => interactionRange;

        private bool canInteract;
        public bool CanInteract => canInteract;

        private bool isInteracting;
        public bool IsInteracting => isInteracting;
        
        public delegate void InteractDelegate(GameObject interactor);
        public event InteractDelegate OnInteract;
        public delegate void StopInteractDelegate();
        public event StopInteractDelegate OnStopInteract;
        public delegate void OnCameInRangeDelegate();
        public event OnCameInRangeDelegate OnCameInRange;
        public delegate void OnCameOutOfRangeDelegate();
        public event OnCameOutOfRangeDelegate OnCameOutOfRange;

        protected CapsuleCollider capsuleCollider;
        protected virtual void Awake() 
        {
            capsuleCollider = GetComponent<CapsuleCollider>();
            if(capsuleCollider == null)
            {
                GameObject go = new GameObject();
                go.transform.SetParent(transform);
                CapsuleCollider newCollider = go.AddComponent<CapsuleCollider>();
                capsuleCollider = newCollider;
            }
            capsuleCollider.radius = interactionRange;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        protected virtual void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject != gameObject && other.CompareTag("Player"))
            {
                OnEnterInteractionRange();
            }
        }

        protected virtual void OnTriggerExit(Collider other) 
        {
            if(other.gameObject != gameObject && other.CompareTag("Player"))
            {
                OnExitInteractionRange();
            }
        }

        protected virtual void OnEnterInteractionRange() 
        {
            OnCameInRange?.Invoke();
            InRange.Add(this);
        }

        protected virtual void OnExitInteractionRange() 
        {
            OnCameOutOfRange?.Invoke();
            InRange.Remove(this);
        }

        public virtual void Interact(GameObject interactor) 
        {
            OnInteract?.Invoke(interactor);
        }

        protected virtual void StopInteract() 
        {
            OnStopInteract?.Invoke();
        }
    }
}
