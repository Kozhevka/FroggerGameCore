using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameStatusEnum;

public class UI_ActivateGame : MonoBehaviour
{
    GameStatusEnum gameStatusEnum;

    [SerializeField] GameObject ui_StartMenu;
    [SerializeField] GameObject ui_IsGameActive;


    //Input Enable
    [SerializeField] GameObject inputHolder;
    TouchInput touchInputScript;



    // Start is called before the first frame update
    void Start()
    {
        

        gameStatusEnum = GameObject.Find("GameManager").GetComponent<GameStatusEnum>();

        Application.targetFrameRate = 60;

        touchInputScript = inputHolder.GetComponent<TouchInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameStatusEnum.gameStatus = GameStatus.GameIsActive;
        touchInputScript.enabled = true;
        
        

        ui_StartMenu.SetActive(false);
        ui_IsGameActive.SetActive(true);
    }
}
