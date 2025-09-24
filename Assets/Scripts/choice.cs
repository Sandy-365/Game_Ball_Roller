using UnityEngine;
using UnityEngine.SceneManagement;

public class optipns : MonoBehaviour
{
    public void play()
    {
        // Debug.Log("Play");
        // InterstitialAD adManager = FindObjectOfType<InterstitialAD>();

        // if (adManager != null)
        // {
        //     adManager.ShowInterstitialAd(() =>
        //     {
        //         SceneManager.LoadScene("_2_Level_Menu");
        //     });
        // }
        // else
        // {
        //     Debug.LogWarning("Ad manager not found, loading scene anyway.");
        //     SceneManager.LoadScene("_2_Level_Menu");
        // }
        //NIce i am fine checking the git version controll
        SceneManager.LoadScene("_2_selectMode");
    }

    public void options()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("SETTINGS");
    }

    public void multi()
    {
        Debug.Log("MultiPlayer");
        SceneManager.LoadScene("multi_1_loading");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void resume()
    {
        Debug.Log("resume pressed");
    }
}
