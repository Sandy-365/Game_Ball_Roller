using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class H_GameManager : MonoBehaviour
{
    public M_new_multiPlayerMovement movement;
    public TextMeshProUGUI textOver;
    public TextMeshProUGUI level_count;
    public TextMeshProUGUI lose_count;
    public s_Score score;
    public GameObject completelevelui;
    public GameObject GameOverUI;
    // public GameObject movementButtons;

    public GameObject play;
    public void EndGame()
    {
        Debug.Log("H_GameOver");
        movement.enabled = false;
        lose_count.SetText((SceneManager.GetActiveScene().buildIndex - 13).ToString());
        
        // movementButtons.SetActive(false);
        play.SetActive(false);
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
        level_count.SetText((SceneManager.GetActiveScene().buildIndex - 13).ToString());
        // movementButtons.SetActive(false);
        play.SetActive(false);
        completelevelui.SetActive(true);
    }
}
