using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c_GameManager : MonoBehaviour
{
    public c_PlayerMovement movement;
    public TextMeshProUGUI textOver;
    public TextMeshProUGUI level_count;
    public TextMeshProUGUI lose_count;
    public c_Score score;
    public GameObject completelevelui;
    public GameObject GameOverUI;
    public GameObject movementButtons;
    public void EndGame()
    {
        Debug.Log("GameOver");
        movement.enabled = false;
        lose_count.SetText((SceneManager.GetActiveScene().buildIndex-16).ToString());
        
        movementButtons.SetActive(false);
        GameOverUI.SetActive(true);
        // Invoke("Restart",3f);
    }

    void Restart()
    {
        Debug.Log("Helloo again");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void finish()
    {
        movement.enabled = false;
        score.enabled = false;
        textOver.SetText("");
        level_count.SetText((SceneManager.GetActiveScene().buildIndex-16).ToString());
        movementButtons.SetActive(false);
        completelevelui.SetActive(true);
        Debug.Log("Hii i am ad");
    }
}
