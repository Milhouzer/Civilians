using UnityEngine;

namespace Milhouzer.Utility
{
    public class FaceCamera : MonoBehaviour
    {
        private void Update()
        {
            // Ensure the canvas always faces the main camera
            if (Camera.main != null)
            {
                transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                                Camera.main.transform.rotation * Vector3.up);
            }
        }
    }
}
