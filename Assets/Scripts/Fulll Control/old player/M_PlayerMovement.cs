// using UnityEngine;
// using System.Collections;
// using Photon.Pun;

// public class multiPlayerMovement : MonoBehaviourPunCallbacks
// {
//     public Rigidbody rb;
//     private float forwardForce = 10f;
//     private float sideForce = 10f; // Side movement speed
//     private float backwardForce = 10f; // Slower than forward for better control

//     private bool moveLeft = false;
//     private bool moveRight = false;
//     private bool moveForward = false;
//     private bool moveBackward = false;
//     PhotonView view;

//     void Start(){
//         view  = GetComponent<PhotonView>();
//     }

//     void FixedUpdate()
//     {
//         if(!view.IsMine)return;
//         // ---- 🎮 PC & WebGL Keyboard Controls ----
//         if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
//         {
//             rb.AddForce(-sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         }

//         if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
//         {
//             rb.AddForce(sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         }

//         if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
//         {
//             rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
//         }

//         if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
//         {
//             rb.AddForce(0, 0, -backwardForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
//         }

//         // ---- 📱 Mobile Touch Controls ----
//         if (moveLeft)
//         {
//             rb.AddForce(-sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         }

//         if (moveRight)
//         {
//             rb.AddForce(sideForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
//         }

//         if (moveForward)
//         {
//             rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
//         }

//         if (moveBackward)
//         {
//             rb.AddForce(0, 0, -backwardForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
//         }
//     }

//     // ---- 📱 Mobile UI Button Controls ----
//     public void LeftButtonDown() { moveLeft = true; }
//     public void LeftButtonUp() { moveLeft = false; }

//     public void RightButtonDown() { moveRight = true; }
//     public void RightButtonUp() { moveRight = false; }

//     public void ForwardButtonDown() { moveForward = true; }
//     public void ForwardButtonUp() { moveForward = false; }

//     public void BackwardButtonDown() { moveBackward = true; }
//     public void BackwardButtonUp() { moveBackward = false; }
// }

// // using UnityEngine;
// // using Photon.Pun;

// // public class multiPlayerMovement : MonoBehaviourPunCallbacks
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
