using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SETTINGS : MonoBehaviour
{
    public Button graphicsSet;
    public Button audioSet;
    public Button controlsSet;

    public GameObject graphicWin;
    public GameObject audioWin;
    public GameObject controlWin;
    public GameObject graphicBack;
    public GameObject audioBack;
    public GameObject controlBack;
    void Start()
    {
        // Assign button click listeners
        graphicsSet.onClick.AddListener(ShowGraphics);
        audioSet.onClick.AddListener(ShowAudio);
        controlsSet.onClick.AddListener(ShowControls);
    }

    void ShowGraphics()
    {
        graphicWin.SetActive(true);
        audioWin.SetActive(false);
        controlWin.SetActive(false);

        graphicBack.SetActive(true);
        audioBack.SetActive(false);
        controlBack.SetActive(false);
    }
    void ShowAudio()
    {
        graphicWin.SetActive(false);
        audioWin.SetActive(true);
        controlWin.SetActive(false);

        
        graphicBack.SetActive(false);
        audioBack.SetActive(true);
        controlBack.SetActive(false);
    }
    void ShowControls()
    {
        graphicWin.SetActive(false);
        audioWin.SetActive(false);
        controlWin.SetActive(true);
        
        graphicBack.SetActive(false);
        audioBack.SetActive(false);
        controlBack.SetActive(true);
    }

    public void backButton()
    {
        Debug.Log("Back Pressed");
        SceneManager.LoadScene("_1_Main_Menu");
    }
}
