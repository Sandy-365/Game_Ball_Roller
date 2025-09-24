using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class H_GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart(){
        // Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Main_Menu(){
        // Debug.Log("Main_Menu");
        SceneManager.LoadScene(11);
    }
}
