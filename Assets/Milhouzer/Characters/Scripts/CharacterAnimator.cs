using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.Character
{
    public abstract class CharacterAnimator : MonoBehaviour
    {
        [SerializeField]
        protected Animator animator;
        protected CharacterController controller;

        protected virtual void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        protected virtual void Update()
        {
            UpdateAnimator();
        }

        protected abstract void UpdateAnimator();
        
    }
}