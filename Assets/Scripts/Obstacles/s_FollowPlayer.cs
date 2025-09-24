using UnityEngine;

public class s_FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Vector3 offset = new Vector3(0, 2, -5); // Camera offset
    public float smoothSpeed = 5f; // Smooth movement speed

    void LateUpdate()
    {
        if (player != null)
        {
            // Smoothly move the camera to follow the player
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
