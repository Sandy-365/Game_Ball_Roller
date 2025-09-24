using UnityEngine;
using UnityEngine.SceneManagement;

public class H_finish : MonoBehaviour
{
    void OnTriggerEnter()
    {
        Debug.Log("H_finish");
        UnlockNewLevel();
        Debug.Log("Reached level H"+PlayerPrefs.GetInt("ReachedIndex_H"));
        Debug.Log("Unlocking the new level H" + PlayerPrefs.GetInt("UnlockedLevel_H"));
        FindObjectOfType<H_GameManager>().finish();
    }
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex_H"))
        {
            PlayerPrefs.SetInt("ReachedIndex_H", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel_H", PlayerPrefs.GetInt("UnlockedLevel_H", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
