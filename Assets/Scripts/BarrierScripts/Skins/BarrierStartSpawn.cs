using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierStartSpawn : MonoBehaviour
{
    
    float stepDistance;
    int stepsToSpawn;

    [SerializeField] GameObject playerMoveObj;

    SpawnRoadManager spawnRoadManager;
    

    

    void Start()
    {
        stepDistance = playerMoveObj.GetComponent<PlayerMove>().stepDistance;

        stepsToSpawn = BarrierValueHolder.barrierValueHolder.stepsToSpawn;

        spawnRoadManager = this.gameObject.GetComponent<SpawnRoadManager>();

        
    }


    public void RestartSpawn()
    {
        Debug.Log("RestartSpawn");
        for (int i = 1; i < stepsToSpawn; i++) 
        {
            Debug.Log("Try to respawn start " + i);
            spawnRoadManager.SpawnOneRoad(stepDistance * i);
            
        }
        


    }
}
