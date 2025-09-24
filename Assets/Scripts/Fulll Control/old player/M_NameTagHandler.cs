// using UnityEngine;

// public class NameTagHandler : MonoBehaviour
// {
//     public Transform player; // Assign Player in Inspector
//     public Vector3 offset = new Vector3(0, 2, 0); // Adjust height

//     void Update()
//     {
//         // Keep the name tag positioned above the player
//         transform.position = player.position + offset;

//         // Make the name tag always face the camera
//         transform.LookAt(Camera.main.transform);
//         transform.Rotate(0, 180, 0); // Flip to face correctly
//     }
// }


using UnityEngine;

public class NameTagHandler : MonoBehaviour
{
    public Transform player; // Assign Player in Inspector
    public Vector3 offset = new Vector3(0, 2, 0); // Adjust height

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player is not assigned to NameTagHandler!");
            return;
        }

        // Keep the name tag positioned above the player
        transform.position = player.position + offset;

        // Find the Main Camera safely
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            // Make the name tag always face the camera
            transform.LookAt(mainCam.transform);
            transform.Rotate(0, 180, 0); // Flip text correctly
        }
        else
        {
            Debug.LogWarning("Main Camera not found! Make sure a camera is in the scene and tagged as 'MainCamera'.");
        }
    }
}
