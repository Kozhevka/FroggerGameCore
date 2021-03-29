using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameStatusEnum;

public class UI_GameOver : MonoBehaviour
{
    GameStatusEnum gameStatusEnum;

    [SerializeField] TextMeshProUGUI gettedScore;

    [SerializeField] GameObject ui_GameIsActive;
    [SerializeField] GameObject ui_GameOver;
    [SerializeField] GameObject ui_StartMenu;

    [SerializeField] Transform playerNextPosition;
    [SerializeField] Transform playerCurrentPosition;


    Vector3 startPlayerPosition;
    
    ScoreCount scoreCount;

    BarrierStartSpawn barrierStartSpawnScript;
    // Start is called before the first frame update
    void Start()
    {
        gameStatusEnum = GameObject.Find("GameManager").GetComponent<GameStatusEnum>();
        scoreCount = GameObject.Find("GameManager").GetComponent<ScoreCount>();
        barrierStartSpawnScript = GameObject.Find("BarrierSpawnManager").GetComponent<BarrierStartSpawn>();

        startPlayerPosition = playerNextPosition.transform.position; //positionAt start
    }

    public void GameOver()
    {
        Debug.Log("Game  Over!!!");
        gameStatusEnum.gameStatus = GameStatus.GameOver;

        ui_GameIsActive.SetActive(false);
        ui_GameOver.SetActive(true);
        

        gettedScore.text = "Your score: " + scoreCount.Score;
    }
    public void RestartGame()
    {
        ui_GameOver.SetActive(false);
        
        BarrierPool.SharedInstance.DeactivateAllPooledObjects();

        playerNextPosition.transform.position = startPlayerPosition;
        playerCurrentPosition.transform.position = startPlayerPosition;

        gameStatusEnum.gameStatus = GameStatus.StartMenu;
        scoreCount.RestartScore();
        barrierStartSpawnScript.RestartSpawn();

        ui_StartMenu.SetActive(true);

    }
}
