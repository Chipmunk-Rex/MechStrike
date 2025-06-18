using System;
using UnityEngine;

namespace MechStrike.Mech
{
    public class Mech : MonoBehaviour
    {
        [SerializeField] Transform mechUpperBody;
        [SerializeField] Vector3 rotationOffset;

        private void FixedUpdate()
        {
            if (mechUpperBody == null)
            {
                Debug.LogError("Mech upper body transform is not assigned.");
                return;
            }

            // Rotate the mech's upper body to face the camera
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0; // Keep the rotation on the horizontal plane
            Quaternion targetRotation =
                Quaternion.LookRotation(cameraForward, Vector3.up) * Quaternion.Euler(rotationOffset);
            mechUpperBody.rotation = Quaternion.Slerp(mechUpperBody.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}