using UnityEngine;

public class SecondCam : MonoBehaviour
{
    public Transform player;           // Player to follow
    public Vector3 offset = new Vector3(0, 3, -6); // Offset from player
    public float followSpeed = 5f;     // Speed at which camera follows

    void LateUpdate()
    {
        if (player == null) return;

        // Desired position based on player position and offset
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Always look at the player
        transform.LookAt(player);
    }
}
