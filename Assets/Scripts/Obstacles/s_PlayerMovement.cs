using UnityEngine;
using System.Collections;
using TMPro; // Import TextMeshPro namespace

public class s_PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    private float forwardForce = 1200f;
    private float sideForce = 30f; // Increased for mobile speed boost

    public Transform player;
    private float mobileSensitivity = 3f; // Tilt sensitivity for mobile
    private float dragSensitivity = 0.1f; // Sensitivity for mouse dragging (WebGL)

    private Vector3 lastMousePosition;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool gameStarted = false; // Prevents movement before delay
    private float startDelay = 4f; // Delay before the game starts

    public TextMeshProUGUI countDownText; // Reference to Countdown Text

    void Start()
    {
        StartCoroutine(StartGameAfterDelay()); // Start delay before enabling movement
    }

    IEnumerator StartGameAfterDelay()
    {
        // Countdown from 3 to 1
        for (int i = 3; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(1.5f);
        }

        countDownText.text = "GO!"; // Show "GO!" before the game starts
        yield return new WaitForSeconds(1f);
        
        countDownText.gameObject.SetActive(false); // Hide countdown text
        gameStarted = true;
    }

    void FixedUpdate()
    {
        if (!gameStarted) return; // Stop movement until the delay is over

        // Move forward continuously
        rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime); // Changed to fixedDeltaTime for smoother movement

        // ---- 🖥️ WebGL & PC Keyboard Controls ----
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // ---- 🌐 WebGL Mouse Drag Controls ----
        // if (Application.platform == RuntimePlatform.WebGLPlayer)
        // {
        //     if (Input.GetMouseButtonDown(0)) // Detect initial click
        //     {
        //         lastMousePosition = Input.mousePosition;
        //     }
        //     else if (Input.GetMouseButton(0)) // Dragging
        //     {
        //         float deltaX = Input.mousePosition.x - lastMousePosition.x;
        //         rb.AddForce(deltaX * dragSensitivity, 0, 0, ForceMode.VelocityChange);
        //         lastMousePosition = Input.mousePosition;
        //     }
        // }

        // ---- 📱 Mobile Touch Controls ----
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);

        //     if (touch.position.x < Screen.width / 2) // Left Side Touch
        //     {
        //         rb.AddForce(-sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        //     }
        //     else if (touch.position.x > Screen.width / 2) // Right Side Touch
        //     {
        //         rb.AddForce(sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        //     }
        // }

        // ---- 📱 Mobile Tilt Controls (Accelerometer) ----
        // if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        // {
        //     float tilt = Input.acceleration.x; // Get device tilt
        //     rb.AddForce(tilt * mobileSensitivity * sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        // }

        // Move left while button is pressed
        if (moveLeft)
        {
            rb.AddForce(-sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Move right while button is pressed
        if (moveRight)
        {
            rb.AddForce(sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    void Update()
    {
        if (!gameStarted) return;
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
