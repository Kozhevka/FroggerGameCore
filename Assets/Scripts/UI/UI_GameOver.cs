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

    
    GameManagerMain mainGameManagerScript;

    [SerializeField] Transform playerNextPosition;
    [SerializeField] Transform playerCurrentPosition;


    Vector3 startPlayerPosition;
    
    ScoreCount scoreCount;

    BarrierStartSpawn barrierStartSpawnScript;
    UI_TopScore topScoreScript;

    //PlayerData***********************************************************************

    MainData mainDataScript;

    //Input Disabable
    [SerializeField] GameObject inputHolder;
    TouchInput touchInputScript;

    // Start is called before the first frame update
    void Start()
    {
        mainDataScript = GameObject.Find("PlayerData").GetComponent<MainData>();
        gameStatusEnum = GameObject.Find("GameManager").GetComponent<GameStatusEnum>();
        scoreCount = GameObject.Find("GameManager").GetComponent<ScoreCount>();
        topScoreScript = this.gameObject.GetComponent<UI_TopScore>();
        barrierStartSpawnScript = GameObject.Find("BarrierSpawnManager").GetComponent<BarrierStartSpawn>();

        startPlayerPosition = playerNextPosition.transform.position; //positionAt start

        touchInputScript = inputHolder.GetComponent<TouchInput>();

        mainGameManagerScript = this.gameObject.GetComponent<GameManagerMain>();
    }

    public void GameOver()
    {
        //Debug.Log("Game  Over!!!");
        mainDataScript.UpdateBalance((int)scoreCount.Score);
        topScoreScript.GetNewResult((int)scoreCount.Score);

        gameStatusEnum.gameStatus = GameStatus.GameOver;
        touchInputScript.enabled = false;
        
        ui_GameIsActive.SetActive(false);
        ui_GameOver.SetActive(true);
        

        gettedScore.text = "Your score: " + scoreCount.Score;
    }
    public void RestartGame()
    {
        ui_GameIsActive.SetActive(false);
        ui_GameOver.SetActive(false);
        
        mainGameManagerScript.RestartGame();
        //RoadPool.RoadPoolScript.DeactivateAllPooledRoads();

        

        ui_StartMenu.SetActive(true);

    }
}
