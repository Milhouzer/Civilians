using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.Character
{
    public class CharacterMovement : CharacterAnimator
    {
        [SerializeField] private float acceleration = 0.5f;
        [SerializeField] private float moveSpeed = 0.5f;
        [SerializeField] private AnimationCurve speedCurve;
        [SerializeField] private float dampTime = 0.5f;

        private Vector2 currentSpeed;

        public void Move(Vector2 movement)
        {
            CalculateCurrentSpeed(movement);
            if(controller.CurrentState.AllowMovement)
            {           
                transform.position += (transform.forward * currentSpeed.y * speedCurve.Evaluate(currentSpeed.y) + transform.right * currentSpeed.x * speedCurve.Evaluate(currentSpeed.x)) * moveSpeed;
            }
        }

        private void CalculateCurrentSpeed(Vector2 movement)
        {
            currentSpeed = Vector2.Lerp(currentSpeed, movement, acceleration);
        }

        protected override void UpdateAnimator()
        {
            animator.SetFloat("Forward", currentSpeed.y, this.dampTime, Time.deltaTime);
        }
    }
}
