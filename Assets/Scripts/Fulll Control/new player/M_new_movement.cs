// // using UnityEngine;
// // using Photon.Pun;

// // public class new_multiPlayerMovement : MonoBehaviourPunCallbacks
// // {
// //     public Rigidbody rb;
// //     public Transform cameraTransform; // Assign Main Camera in Inspector
// //     private float moveSpeed = 5f; 
// //     private float rotationSpeed = 100f; 

// //     PhotonView view;

// //     void Start()
// //     {
// //         view = GetComponent<PhotonView>();

// //         if (rb == null)
// //         {
// //             rb = GetComponent<Rigidbody>(); // Ensure Rigidbody is assigned
// //         }

// //         if (cameraTransform == null)
// //         {
// //             Debug.LogError("Camera Transform is not assigned!");
// //         }
// //     }

// //     void FixedUpdate()
// //     {
// //         if (!view.IsMine) return; // Only control the local player

// //         // // 🔄 Rotation using Rigidbody
// //         // if (Input.GetKey(KeyCode.D))
// //         // {
// //         //     rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0));
// //         // }
// //         // if (Input.GetKey(KeyCode.A))
// //         // {
// //         //     rb.MoveRotation(rb.rotation * Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0));
// //         // }

// //         // ✅ Move forward in the camera's forward direction
// //         if (Input.GetKey(KeyCode.W))
// //         {
// //             Vector3 forwardDirection = cameraTransform.forward;
// //             forwardDirection.y = 0; // Prevent moving up/down
// //             forwardDirection.Normalize(); 

// //             rb.velocity = new Vector3(forwardDirection.x * moveSpeed, rb.velocity.y, forwardDirection.z * moveSpeed);
// //         }
// //     }
// // }
// using UnityEngine;

// public class M_new_multiPlayerMovement : MonoBehaviour
// {
//     public Rigidbody rb;
//     public Transform cameraTransform; // Assign Main Camera in Inspector
//     public float moveSpeed = 5f;

//     // Movement states
//     private bool isMovingForward = false;
//     private bool isMovingBackward = false;

//     void Start()
//     {
//         if (rb == null)
//         {
//             rb = GetComponent<Rigidbody>(); // Ensure Rigidbody is assigned
//         }

//         if (cameraTransform == null)
//         {
//             Debug.LogError("Camera Transform is not assigned!");
//         }
//     }

//     void Update()
//     {
//         // 🎹 Keyboard input detection

//         if (Input.GetKeyDown(KeyCode.W))
//             isMovingForward = true;

//         if (Input.GetKeyUp(KeyCode.W))
//             isMovingForward = false;

//         if (Input.GetKeyDown(KeyCode.S))
//             isMovingBackward = true;

//         if (Input.GetKeyUp(KeyCode.S))
//             isMovingBackward = false;
//     }

//     void FixedUpdate()
//     {
//         Vector3 moveDirection = Vector3.zero;

//         if (isMovingForward)
//             moveDirection += GetCameraForward();

//         if (isMovingBackward)
//             moveDirection -= GetCameraForward();

//         rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
//     }

//     // 🔄 Get camera forward direction (ignores Y-axis)
//     private Vector3 GetCameraForward()
//     {
//         Vector3 forward = cameraTransform.forward;
//         forward.y = 0;
//         return forward.normalized;
//     }

//     // 🚀 UI Button Event Listeners 👇

//     public void OnMoveForwardDown()
//     {
//         isMovingForward = true;
//     }

//     public void OnMoveForwardUp()
//     {
//         isMovingForward = false;
//     }

//     public void OnMoveBackwardDown()
//     {
//         isMovingBackward = true;
//     }

//     public void OnMoveBackwardUp()
//     {
//         isMovingBackward = false;
//     }
// }


using UnityEngine;

public class M_new_multiPlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cameraTransform; // Assign Main Camera in Inspector
    public float moveSpeed = 5f;

    // Movement states
    private bool isMovingForward = false;
    private bool isMovingBackward = false;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>(); // Ensure Rigidbody is assigned
        }

        if (cameraTransform == null)
        {
            Debug.LogError("Camera Transform is not assigned!");
        }
    }

    void Update()
    {
        // 🎹 Keyboard input detection

        if (Input.GetKeyDown(KeyCode.W))
            isMovingForward = true;

        if (Input.GetKeyUp(KeyCode.W))
            isMovingForward = false;

        if (Input.GetKeyDown(KeyCode.S))
            isMovingBackward = true;

        if (Input.GetKeyUp(KeyCode.S))
            isMovingBackward = false;
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        if (isMovingForward)
            moveDirection += GetCameraForward();

        if (isMovingBackward)
            moveDirection -= GetCameraForward();

        moveDirection = moveDirection.normalized;

        // ✅ Apply force instead of setting velocity directly
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);

        // ✅ Optional: Limit max horizontal speed
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    // 🔄 Get camera forward direction (ignores Y-axis)
    private Vector3 GetCameraForward()
    {
        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    // 🚀 UI Button Event Listeners 👇

    public void OnMoveForwardDown()
    {
        isMovingForward = true;
    }

    public void OnMoveForwardUp()
    {
        isMovingForward = false;
    }

    public void OnMoveBackwardDown()
    {
        isMovingBackward = true;
    }

    public void OnMoveBackwardUp()
    {
        isMovingBackward = false;
    }
}

