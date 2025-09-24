using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectMode : MonoBehaviour
{
    public Button obstacleButton;
    public Button fullButton;
    public Button pathButton;

    void Start()
    {
        obstacleButton.onClick.AddListener(LoadObstacleScene);
        fullButton.onClick.AddListener(LoadFullScene);
        pathButton.onClick.AddListener(LoadPathScene);
    }

    void LoadObstacleScene()
    {
        SceneManager.LoadScene("_1_ObstacleScene"); // Replace with your scene name
    }

    void LoadFullScene()
    {
        SceneManager.LoadScene("_1_FullScene"); // Replace with your scene name
    }

    void LoadPathScene()
    {
        SceneManager.LoadScene("_1_PathScene"); // Replace with your scene name
    }

    public void back(){
        SceneManager.LoadScene("_1_Main_Menu");
    }
}
