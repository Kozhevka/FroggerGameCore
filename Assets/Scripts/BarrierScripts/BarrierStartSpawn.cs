using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierStartSpawn : MonoBehaviour
{
    public static BarrierStartSpawn StartGameSpawner;
    float stepDistance = 2f;
    float distanceToMainSpawn = 30f;

    [SerializeField] GameObject playerMoveObj;
    BarrierSpawn barrierSpawnScript;

    [SerializeField] GameObject[] barriers;

    private void Awake()
    {
        StartGameSpawner = this; 
    }

    void Start()
    {
        stepDistance = playerMoveObj.GetComponent<PlayerMove>().stepDistance;
        distanceToMainSpawn = this.gameObject.GetComponent<BarrierSpawn>().distanceToSpawn;

        
    }


    public void RestartSpawn()
    {
        
        for (int i = 1; i < distanceToMainSpawn/stepDistance + 1; i++)
        {
            this.gameObject.GetComponent<BarrierSpawn>().SpawnOneRoad(stepDistance * i);
            Debug.Log($"Start spawn road {i}");
        }
        


    }
}
