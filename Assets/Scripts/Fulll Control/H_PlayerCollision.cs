using UnityEngine;

public class H_PlayerCollision : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obst")
        {
            FindObjectOfType<H_GameManager>().EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obst")) // Check if the collided object has the tag "Obst"
        {
            FindObjectOfType<H_GameManager>().EndGame();
        }
    }

}
