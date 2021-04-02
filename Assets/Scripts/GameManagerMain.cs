using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMain : MonoBehaviour
{
    ScoreCount scoreCountScript;

    [SerializeField] GameObject mainSpawnManager;
    SpawnRoadManager spawnRoadManager;
    BarrierValueHolder barrierValueHolder;

    int stepsToSpawn;
    float stepDistance;
    // Start is called before the first frame update
    void Start()
    {
        scoreCountScript = this.gameObject.GetComponent<ScoreCount>();
        spawnRoadManager = mainSpawnManager.GetComponent<SpawnRoadManager>();

        stepsToSpawn = BarrierValueHolder.barrierValueHolder.stepsToSpawn;

        stepDistance = GameObject.Find("PlayerNextPosition").GetComponent<PlayerMove>().stepDistance;

        Debug.Log($"desitance to spawn = {stepsToSpawn}");
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
}
