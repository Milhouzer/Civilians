using Unity.VisualScripting;
using UnityEngine;
// using Cinemachine;

namespace Milhouzer.Character
{
    public class CharacterLook : MonoBehaviour
    {
        [SerializeField] private CursorLockMode lockMode = CursorLockMode.Locked;
        [SerializeField] private Transform target;
        [SerializeField] private float horizontalSensitivity;
        [SerializeField] private float verticalSensitivity;
        [SerializeField] private float horizontalDampTime = .1f;
        [SerializeField] private float verticalDampTime = .1f;
        [SerializeField] private Vector2 verticalClamp;

        private float horizontalRotation = 0f;
        private float verticalRotation = 0f;

        private CharacterController controller;

        private void Awake() 
        {
            Cursor.lockState = lockMode;
            controller = GetComponent<CharacterController>();
        }

        public void Look(Vector2 look)
        {
            horizontalRotation = Mathf.Lerp(horizontalRotation, look.x * horizontalSensitivity * Time.deltaTime, horizontalDampTime);
            verticalRotation = Mathf.Lerp(verticalRotation, look.y * verticalSensitivity * Time.deltaTime, verticalDampTime);

            if(controller.CurrentState.AllowCameraRotation)
            {
                Vector3 targetEulerAngles = target.rotation.eulerAngles;
                targetEulerAngles.x = Mathf.Clamp(targetEulerAngles.x - verticalRotation - (((targetEulerAngles.x - verticalRotation) >= 180f) ? 360 : 0), verticalClamp.x, verticalClamp.y);
                target.rotation = Quaternion.Euler(targetEulerAngles);
            }

            if(controller.CurrentState.AllowCharacterRotation)
            {
                Quaternion selfRotation = Quaternion.Euler(0f, horizontalRotation, 0f);
                transform.rotation *= selfRotation;
            }
        }
    }
}
