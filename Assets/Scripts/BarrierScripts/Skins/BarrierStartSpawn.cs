using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierStartSpawn : MonoBehaviour
{
    public static BarrierStartSpawn barrierStartSpawn;
    float stepDistance;
    int stepsToSpawn;

    GameObject playerMoveObj;

    SpawnRoadManager spawnRoadManager;

    int frameCounter = 0;


    private void Awake()
    {
        //barrierStartSpawn = this;

        //ResetFrame counter for swiping skins
        frameCounter = 0;
    }

    void Start()
    {
        playerMoveObj = GameObject.Find("PlayerNextPosition");

        stepDistance = playerMoveObj.GetComponent<PlayerMove>().stepDistance;

        stepsToSpawn = BarrierValueHolder.barrierValueHolder.stepsToSpawn;

        
    }
    private void Update()
    {
        if (frameCounter == 0)
            frameCounter++;
        if (frameCounter == 1)
        {
            RestartSpawn();
            frameCounter++;
        }
    }

    public void RestartSpawn()
    {
        spawnRoadManager = GameObject.Find("SkinShell").GetComponent<SpawnRoadManager>();
        //Debug.Log("RestartSpawn");
        for (int i = 1; i < stepsToSpawn + 1; i++) 
        {
            //Debug.Log("Try to respawn start " + i);
            spawnRoadManager.SpawnOneRoad(stepDistance * i);
            
        }
        


    }
}
