using UnityEngine;

public class s_PlayerCollision : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obst")
        {
            Debug.Log("OBST");
            FindObjectOfType<s_GameManager>().EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obst")) // Check if the collided object has the tag "Obst"
        {
            Debug.Log("Trigger");
            FindObjectOfType<s_GameManager>().EndGame();
        }
    }

}
