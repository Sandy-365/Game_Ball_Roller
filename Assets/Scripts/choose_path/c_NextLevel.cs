using UnityEngine;
using UnityEngine.SceneManagement;

public class c_NextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("_1_PathScene");
    }
}
