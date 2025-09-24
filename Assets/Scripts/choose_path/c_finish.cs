using UnityEngine;
using UnityEngine.SceneManagement;

public class c_finish : MonoBehaviour
{
    void OnTriggerEnter()
    {
        UnlockNewLevel();
        Debug.Log("Reached level_C "+PlayerPrefs.GetInt("ReachedIndex_C"));
        Debug.Log("Unlocking the new level_C " + PlayerPrefs.GetInt("UnlockedLevel_C"));
        FindObjectOfType<c_GameManager>().finish();
    }
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex_C"))
        {
            PlayerPrefs.SetInt("ReachedIndex_C", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel_C", PlayerPrefs.GetInt("UnlockedLevel_C", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
