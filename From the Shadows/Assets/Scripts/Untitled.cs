using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Untitled : MonoBehaviour
{
    public Transform target; // The player character to follow
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset from the target's position
    public float rotationSpeed = 1f; // Speed of camera rotation

    private float mouseX, mouseY;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Rotate the camera based on mouse input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35f, 60f); // Limit vertical rotation

        // Calculate rotation for the camera based on mouse input
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

        // Apply rotation to the camera position offset
        Vector3 desiredPosition = target.position - rotation * offset;

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.1f);

        // Look at the player character
        transform.LookAt(target);
    }
}
