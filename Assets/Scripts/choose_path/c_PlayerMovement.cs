// using UnityEngine;
// using System.Collections;
// using TMPro; // Import TextMeshPro namespace

// public class c_PlayerMovement : MonoBehaviour
// {
//     public Rigidbody rb;
//     private float forwardForce = 1200f;
//     private float sideForce = 30f; // Increased for mobile speed boost

//     public Transform player;
//     private float mobileSensitivity = 3f; // Tilt sensitivity for mobile
//     private float dragSensitivity = 0.1f; // Sensitivity for mouse dragging (WebGL)

//     private Vector3 lastMousePosition;

//     private bool moveLeft = false;
//     private bool moveRight = false;
//     private bool gameStarted = false; // Prevents movement before delay
//     private float startDelay = 4f; // Delay before the game starts

//     public TextMeshProUGUI countDownText; // Reference to Countdown Text

//     void Start()
//     {
//         StartCoroutine(StartGameAfterDelay()); // Start delay before enabling movement
//     }

//     IEnumerator StartGameAfterDelay()
//     {
//         // Countdown from 3 to 1
//         for (int i = 3; i > 0; i--)
//         {
//             countDownText.text = i.ToString();
//             yield return new WaitForSeconds(1.5f);
//         }

//         countDownText.text = "GO!"; // Show "GO!" before the game starts
//         yield return new WaitForSeconds(1f);
        
//         countDownText.gameObject.SetActive(false); // Hide countdown text
//         gameStarted = true;
//     }

//     void FixedUpdate()
//     {
//         if (!gameStarted) return; // Stop movement until the delay is over

//         // Move forward continuously
//         rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime); // Changed to fixedDeltaTime for smoother movement

//         // ---- 🖥️ WebGL & PC Keyboard Controls ----
//         if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
//         {
//             rb.AddForce(-sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         }

//         if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
//         {
//             rb.AddForce(sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         }

//         // ---- 🌐 WebGL Mouse Drag Controls ----
//         // if (Application.platform == RuntimePlatform.WebGLPlayer)
//         // {
//         //     if (Input.GetMouseButtonDown(0)) // Detect initial click
//         //     {
//         //         lastMousePosition = Input.mousePosition;
//         //     }
//         //     else if (Input.GetMouseButton(0)) // Dragging
//         //     {
//         //         float deltaX = Input.mousePosition.x - lastMousePosition.x;
//         //         rb.AddForce(deltaX * dragSensitivity, 0, 0, ForceMode.VelocityChange);
//         //         lastMousePosition = Input.mousePosition;
//         //     }
//         // }

//         // ---- 📱 Mobile Touch Controls ----
//         // if (Input.touchCount > 0)
//         // {
//         //     Touch touch = Input.GetTouch(0);

//         //     if (touch.position.x < Screen.width / 2) // Left Side Touch
//         //     {
//         //         rb.AddForce(-sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         //     }
//         //     else if (touch.position.x > Screen.width / 2) // Right Side Touch
//         //     {
//         //         rb.AddForce(sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         //     }
//         // }

//         // ---- 📱 Mobile Tilt Controls (Accelerometer) ----
//         // if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
//         // {
//         //     float tilt = Input.acceleration.x; // Get device tilt
//         //     rb.AddForce(tilt * mobileSensitivity * sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         // }

//         // Move left while button is pressed
//         if (moveLeft)
//         {
//             rb.AddForce(-sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         }

//         // Move right while button is pressed
//         if (moveRight)
//         {
//             rb.AddForce(sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         }
//     }

//     void Update()
//     {
//         if (!gameStarted) return;
//     }

//     public void LeftButtonDown()
//     {
//         moveLeft = true;
//     }

//     public void LeftButtonUp()
//     {
//         moveLeft = false;
//     }

//     public void RightButtonDown()
//     {
//         moveRight = true;
//     }

//     public void RightButtonUp()
//     {
//         moveRight = false;
//     }
// }


using UnityEngine;
using System.Collections;
using TMPro;

public class c_PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    [Header("Movement Settings")]
    public float forwardForce = 1200f;
    public float sideForce = 30f;

    [Header("Acceleration Settings")]
    public float acceleration = 50f;
    public float maxForwardForce = 3000f;

    [Header("Sensitivity Settings")]
    public float mobileSensitivity = 3f;
    public float dragSensitivity = 0.1f;

    [Header("Countdown Settings")]
    public float startDelay = 4f;
    public TextMeshProUGUI countDownText;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool gameStarted = false;

    void Start()
    {
        StartCoroutine(StartGameAfterDelay());
    }

    IEnumerator StartGameAfterDelay()
    {
        for (int i = 3; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(1.5f);
        }

        countDownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countDownText.gameObject.SetActive(false);
        gameStarted = true;
    }

    void FixedUpdate()
    {
        if (!gameStarted) return;

        // Increase forward force over time
        if (forwardForce < maxForwardForce)
        {
            forwardForce += acceleration * Time.fixedDeltaTime;
        }

        // Apply constant forward velocity
        Vector3 velocity = rb.velocity;
        velocity.z = forwardForce * Time.fixedDeltaTime;
        rb.velocity = velocity;

        // Side movement (add velocity directly, clean)
        Vector3 sideVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a") || moveLeft)
        {
            sideVelocity.x = -sideForce;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d") || moveRight)
        {
            sideVelocity.x = sideForce;
        }

        rb.AddForce(sideVelocity * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    public void LeftButtonDown()
    {
        moveLeft = true;
    }

    public void LeftButtonUp()
    {
        moveLeft = false;
    }

    public void RightButtonDown()
    {
        moveRight = true;
    }

    public void RightButtonUp()
    {
        moveRight = false;
    }
}
