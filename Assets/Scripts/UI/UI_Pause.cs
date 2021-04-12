using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    [SerializeField] GameObject isGameActiveUI;
    [SerializeField] GameObject pauseUI;

    //Input Deligation
    [SerializeField] GameObject inputHolder;
    TouchInput touchInputScript;


    void Start()
    {
        touchInputScript = inputHolder.GetComponent<TouchInput>();
    }
    //[SerializeField] TextMeshproUGUI scoreText;

    public void PauseButton()
    {
        touchInputScript.enabled = false;
        Time.timeScale = 0f;
        isGameActiveUI.SetActive(false);
        pauseUI.SetActive(true);

    }

    public void UnpauseButton()
    {
        touchInputScript.enabled = true;
        pauseUI.SetActive(false);
        isGameActiveUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
