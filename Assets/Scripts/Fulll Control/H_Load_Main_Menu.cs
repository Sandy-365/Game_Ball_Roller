using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class H_Load_Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("H Loading the main Menu");
        Invoke("Load_Menu",5f);
    }

    void Load_Menu(){
        SceneManager.LoadScene(0);
    }
}
