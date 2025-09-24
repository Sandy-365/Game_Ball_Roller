// using UnityEngine;

// public class M_FollowPlayer : MonoBehaviour
// {
//     public Transform player; // Player's Transform (center point)
//     public Vector3 offset = new Vector3(0, 2, -5); // Default camera offset
//     public float rotationSpeed = 100f; // Speed of rotation

//     private Camera mainCamera; // Reference to the Main Camera

//     // 🔄 Rotation states for button input
//     private bool isRotatingLeft = false;
//     private bool isRotatingRight = false;

//     void Start()
//     {
//         // Disable the Main Camera if it exists
//         mainCamera = Camera.main;
//         if (mainCamera != null)
//         {
//             mainCamera.gameObject.SetActive(false);
//         }

//         // Set this camera as active
//         GetComponent<Camera>().enabled = true;

//         // Ensure correct start position
//         transform.position = player.position + offset;
//     }

//     void LateUpdate()
//     {
//         float rotationInput = 0f;

//         // 🎹 Keyboard input
//         if (KeyDown(KeyCode.A)) rotationInput = -1f;
//         if (KeyDown(KeyCode.D)) rotationInput = 1f;

//         // 🎮 Button input
//         if (isRotatingLeft) rotationInput = -1f;
//         if (isRotatingRight) rotationInput = 1f;

//         // 🌍 Rotate the offset around the player
//         if (rotationInput != 0f)
//         {
//             Quaternion rotation = Quaternion.Euler(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
//             offset = rotation * offset;
//         }

//         // 🔄 Apply new position while keeping the offset distance
//         transform.position = player.position + offset;

//         // 👀 Camera always looks at the player
//         transform.LookAt(player);
//     }

//     // 🚀 Custom Input Handling (Detect if a key is pressed)
//     private bool KeyDown(KeyCode key)
//     {
//         return (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Windows && Input.GetKey(key)) ||
//                (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Linux && Input.GetKey(key)) ||
//                (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX && Input.GetKey(key));
//     }

//     // 🎮 UI Button Event Listeners

//     public void OnRotateLeftDown()
//     {
//         isRotatingLeft = true;
//     }

//     public void OnRotateLeftUp()
//     {
//         isRotatingLeft = false;
//     }

//     public void OnRotateRightDown()
//     {
//         isRotatingRight = true;
//     }

//     public void OnRotateRightUp()
//     {
//         isRotatingRight = false;
//     }
// }




// using UnityEngine;

// public class M_FollowPlayer : MonoBehaviour
// {
//     public Transform player; // Player's Transform (center point)
//     public Vector3 offset = new Vector3(0, 2, -5); // Default camera offset
//     public float rotationSpeed = 100f; // Speed of rotation
//     public float safeHeight = 1.5f; // Height to lift the camera when touching ground

//     private Camera mainCamera; // Reference to the Main Camera

//     private bool isRotatingLeft = false;
//     private bool isRotatingRight = false;

//     void Start()
//     {
//         // Disable the Main Camera if it exists
//         mainCamera = Camera.main;
//         if (mainCamera != null)
//         {
//             mainCamera.gameObject.SetActive(false);
//         }

//         // Set this camera as active
//         GetComponent<Camera>().enabled = true;

//         // Ensure correct start position
//         transform.position = player.position + offset;
//     }

//     void LateUpdate()
//     {
//         float rotationInput = 0f;

//         if (KeyDown(KeyCode.A)) rotationInput = -1f;
//         if (KeyDown(KeyCode.D)) rotationInput = 1f;

//         if (isRotatingLeft) rotationInput = -1f;
//         if (isRotatingRight) rotationInput = 1f;

//         if (rotationInput != 0f)
//         {
//             Quaternion rotation = Quaternion.Euler(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
//             offset = rotation * offset;
//         }

//         Vector3 desiredPosition = player.position + offset;
//         transform.position = desiredPosition;

//         transform.LookAt(player);
//     }

//     // ✅ Detect trigger collision with ground
//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("ground"))
//         {
//             Debug.Log("Camera is in contact with ground!");
            
//             Vector3 position = transform.position;
//             position.y = other.bounds.max.y + safeHeight;
//             transform.position = position;
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("ground"))
//         {
//             Debug.Log("Camera is no longer in contact with ground!");
//         }
//     }

//     private bool KeyDown(KeyCode key)
//     {
//         return (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Windows && Input.GetKey(key)) ||
//                (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Linux && Input.GetKey(key)) ||
//                (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX && Input.GetKey(key));
//     }

//     public void OnRotateLeftDown() => isRotatingLeft = true;
//     public void OnRotateLeftUp() => isRotatingLeft = false;
//     public void OnRotateRightDown() => isRotatingRight = true;
//     public void OnRotateRightUp() => isRotatingRight = false;
// }

using UnityEngine;
using System.Collections;

public class M_FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -5);
    public float rotationSpeed = 100f;

    public Camera secondaryCamera;

    private Camera mainCamera;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    private Coroutine disableSecondaryCamCoroutine;

    private int groundContactCount = 0;
    private bool isInContactWithGround = false;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(false);
        }

        GetComponent<Camera>().enabled = true;

        if (secondaryCamera != null)
        {
            secondaryCamera.enabled = false;
        }

        transform.position = player.position + offset;
    }

    void LateUpdate()
    {
        float rotationInput = 0f;

        if (KeyDown(KeyCode.A)) rotationInput = -1f;
        if (KeyDown(KeyCode.D)) rotationInput = 1f;

        if (isRotatingLeft) rotationInput = -1f;
        if (isRotatingRight) rotationInput = 1f;

        if (rotationInput != 0f)
        {
            Quaternion rotation = Quaternion.Euler(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
            offset = rotation * offset;
        }

        transform.position = player.position + offset;
        transform.LookAt(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            isInContactWithGround = true;
            groundContactCount++;
            Debug.Log($"Camera contact count: {groundContactCount}");

            if (disableSecondaryCamCoroutine != null)
            {
                StopCoroutine(disableSecondaryCamCoroutine);
                disableSecondaryCamCoroutine = null;
            }

            // ✅ Only enable secondary cam after double contact and active contact
            if (groundContactCount >= 2 && secondaryCamera != null && isInContactWithGround)
            {
                secondaryCamera.enabled = true;
                Debug.Log("✅ Secondary camera ENABLED after double contact and active ground contact!");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            isInContactWithGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            isInContactWithGround = false;
            Debug.Log("Camera exited ground!");

            if (disableSecondaryCamCoroutine != null)
            {
                StopCoroutine(disableSecondaryCamCoroutine);
            }
            disableSecondaryCamCoroutine = StartCoroutine(DisableSecondaryCamAfterDelay(2f));
        }
    }

    private IEnumerator DisableSecondaryCamAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (secondaryCamera != null)
        {
            secondaryCamera.enabled = false;
            Debug.Log("Secondary camera DISABLED after delay.");
        }

        groundContactCount = 0;
        disableSecondaryCamCoroutine = null;
    }

    private bool KeyDown(KeyCode key)
    {
        return Input.GetKey(key);
    }

    public void OnRotateLeftDown() => isRotatingLeft = true;
    public void OnRotateLeftUp() => isRotatingLeft = false;
    public void OnRotateRightDown() => isRotatingRight = true;
    public void OnRotateRightUp() => isRotatingRight = false;
}
