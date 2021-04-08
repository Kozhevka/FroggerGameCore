using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    [SerializeField] GameObject isGameActiveUI;
    [SerializeField] GameObject pauseUI;

    //[SerializeField] TextMeshproUGUI scoreText;

    public void PauseButton()
    {
        Time.timeScale = 0f;
        isGameActiveUI.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void UnpauseButton()
    {
        pauseUI.SetActive(false);
        isGameActiveUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
