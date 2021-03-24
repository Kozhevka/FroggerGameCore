using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusEnum : MonoBehaviour
{
    [Header("Check game status in inspector")] //remove this and update when BUILD 
    [SerializeField] bool inStartMenu;
    [SerializeField] bool isGameActive;
    [SerializeField] bool GameOver;

    enum GameStatus
    {
        StartMenu,
        GameIsActive,
        GameOver
    }
    GameStatus gameStatus;

    

    private void Start()
    {
        gameStatus = GameStatus.StartMenu;
    }

    private void Update()
    {
        if (gameStatus == GameStatus.StartMenu)
        {
            inStartMenu = true;
            isGameActive = false;
            GameOver = false;
        }
        else if (gameStatus == GameStatus.GameIsActive)
        {
            inStartMenu = false;
            isGameActive = true;
            GameOver = false;
        }
        else if (gameStatus == GameStatus.GameOver)
        {
            inStartMenu = false;
            isGameActive = false;
            GameOver = true;
        }
    }

    GameStatus ShangeGameStatus (GameStatus setGameStatus)
    {
        if (setGameStatus == GameStatus.StartMenu)
            gameStatus = GameStatus.StartMenu;

        else if (setGameStatus == GameStatus.GameIsActive)
            gameStatus = GameStatus.GameIsActive;

        else if (setGameStatus == GameStatus.GameOver)
            gameStatus = GameStatus.GameOver;
              
        return setGameStatus;
    }

}   
