using UnityEngine;
using UnityEngine.SceneManagement;

public class s_NextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("_1_ObstacleScene");
    }
}
