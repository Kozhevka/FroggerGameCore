using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatusEnum;

public class UI_GameOver : MonoBehaviour
{
    GameStatusEnum gameStatusEnum;

    [SerializeField] GameObject ui_GameIsActive;
    [SerializeField] GameObject ui_GameOver;
    [SerializeField] GameObject ui_StartMenu;
    // Start is called before the first frame update
    void Start()
    {
        gameStatusEnum = GameObject.Find("GameManager").GetComponent<GameStatusEnum>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        gameStatusEnum.gameStatus = GameStatus.GameOver;

        ui_GameIsActive.SetActive(false);
        ui_GameOver.SetActive(true);
    }
    public void RestartGame()
    {
        ui_GameOver.SetActive(false);
        ui_StartMenu.SetActive(true);


        gameStatusEnum.gameStatus = GameStatus.StartMenu;
    }
}
