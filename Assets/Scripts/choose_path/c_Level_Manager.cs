using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class c_Level_Manager : MonoBehaviour
{

    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel_C", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void Back()
    {
        // Debug.Log("Back Menu Pressed");
        SceneManager.LoadScene("_2_selectMode");
    }

    // This method will be assigned to each button's OnClick() event
    public void Choice(int buttonIndex)
    {
        SceneManager.LoadScene(16+buttonIndex);
    }
}
