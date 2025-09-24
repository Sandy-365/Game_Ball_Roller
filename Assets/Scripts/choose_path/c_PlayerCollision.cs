using UnityEngine;

public class c_PlayerCollision : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obst")
        {
            Debug.Log("OBST");
            FindObjectOfType<c_GameManager>().EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obst")) // Check if the collided object has the tag "Obst"
        {
            Debug.Log("Trigger");
            FindObjectOfType<c_GameManager>().EndGame();
        }
    }

}
