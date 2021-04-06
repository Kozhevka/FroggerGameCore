using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatusEnum;

public class GameManagerMain : MonoBehaviour
{
    public static GameManagerMain gameManagerMain;

    ScoreCount scoreCountScript;

    
    SpawnRoadManager spawnRoadManager;
    BarrierValueHolder barrierValueHolder;

    GameObject playerNextPosition;
    GameObject playerCurrentPosition;
    Vector3 startPlayerPosition;

    GameStatusEnum gameStatusEnum;
    

    BarrierStartSpawn barrierStartSpawnScript;

    int stepsToSpawn;
    float stepDistance;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManagerMain = this;
    }

    void Start()
    {
        scoreCountScript = this.gameObject.GetComponent<ScoreCount>();
        gameStatusEnum = GameObject.Find("GameManager").GetComponent<GameStatusEnum>();

        spawnRoadManager = GameObject.Find("SkinShell").GetComponent<SpawnRoadManager>();

        stepsToSpawn = BarrierValueHolder.barrierValueHolder.stepsToSpawn;

        stepDistance = GameObject.Find("PlayerNextPosition").GetComponent<PlayerMove>().stepDistance;

        barrierStartSpawnScript = GameObject.Find("SkinShell").GetComponent<BarrierStartSpawn>();

        Debug.Log($"desitance to spawn = {stepsToSpawn}");

        playerNextPosition = GameObject.Find("PlayerNextPosition");
        playerCurrentPosition = GameObject.Find("PlayerCurrentPosition");
        startPlayerPosition = playerNextPosition.transform.position;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerMadeStepForward(float vectorZposition) //We get current PlayerZPosition;
    {
        //Debug.Log($"desitance to spawn = {stepsToSpawn}");
        //Debug.Log(" PlayerMadeStepForward " +vectorZposition);
        float nextZSpawnPosition = vectorZposition + (stepsToSpawn*stepDistance);

        spawnRoadManager.SpawnOneRoad(nextZSpawnPosition);

        scoreCountScript.OneStepScore();
    }

    public void RestartGame()
    {
        playerNextPosition.transform.position = startPlayerPosition;
        playerCurrentPosition.transform.position = startPlayerPosition;

        gameStatusEnum.gameStatus = GameStatus.StartMenu;

        //Debug.Log("before restart score");
        scoreCountScript.RestartScore();
        //Debug.Log("after restart score");
        spawnRoadManager.DeactivateAllPooledRoads();



        barrierStartSpawnScript.RestartSpawn();
    }
}
