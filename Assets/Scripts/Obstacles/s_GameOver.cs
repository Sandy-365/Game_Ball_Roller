using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        InterstitialAD adManager = FindObjectOfType<InterstitialAD>();

        if (adManager != null)
        {
            adManager.ShowInterstitialAd(() =>
            {
                Debug.Log("Ad finished, loading scene...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }
        else
        {
            Debug.LogWarning("Ad manager not found, loading scene anyway.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Main_Menu()
    {
        // Debug.Log("Main_Menu");
        SceneManager.LoadScene("_1_ObstacleScene");
    }
}
