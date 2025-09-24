using UnityEngine;
using UnityEngine.SceneManagement;

public class H_NextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("_1_FullScene");
    }
}
