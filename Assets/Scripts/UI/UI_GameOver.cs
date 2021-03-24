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
    
    ScoreCount scoreCount;

    BarrierStartSpawn barrierStartSpawnScript;
    // Start is called before the first frame update
    void Start()
    {
        gameStatusEnum = GameObject.Find("GameManager").GetComponent<GameStatusEnum>();
        scoreCount = GameObject.Find("GameManager").GetComponent<ScoreCount>();
        barrierStartSpawnScript = GameObject.Find("BarrierSpawnManager").GetComponent<BarrierStartSpawn>();
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

        gettedScore.text = "Your score: " + scoreCount.Score;
    }
    public void RestartGame()
    {
        ui_GameOver.SetActive(false);
        ui_StartMenu.SetActive(true);
        BarrierPool.SharedInstance.DeactivateAllPooledObjects();

        
        playerNextPosition.transform.position = Vector3.zero;
        barrierStartSpawnScript.RestartSpawn();

        playerCurrentPosition.transform.position = Vector3.zero;
        


        scoreCount.RestartScore();
        gameStatusEnum.gameStatus = GameStatus.StartMenu;
    }
}
