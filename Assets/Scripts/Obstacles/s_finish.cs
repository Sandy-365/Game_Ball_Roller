using UnityEngine;
using UnityEngine.SceneManagement;

public class s_finish : MonoBehaviour
{
    void OnTriggerEnter()
    {
        UnlockNewLevel();
        Debug.Log("Reached level "+PlayerPrefs.GetInt("ReachedIndex"));
        Debug.Log("Unlocking the new level " + PlayerPrefs.GetInt("UnlockedLevel"));
        FindObjectOfType<s_GameManager>().finish();
    }
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
