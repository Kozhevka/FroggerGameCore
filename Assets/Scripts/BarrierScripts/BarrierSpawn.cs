using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawn : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    PlayerMove playerMoveScript;
    BarrierDublicate barrierDublicateScript;
    

    public float distanceToSpawn = 40f;
    float spawnZPosition;

    float randSpawnXRange = 4;

    bool rotateBarierForCorrectQueue = true;


    // Start is called before the first frame update
    void Start()
    {
        playerMoveScript = playerObject.GetComponent<PlayerMove>();

        barrierDublicateScript = GetComponent<BarrierDublicate>();
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0f, 0f, playerObject.transform.position.z);

        //spawnZPosition = this.transform.position.z + distanceToSpawn;
    }

    public void SpawnOneRoad(float spawnPositionZ)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-randSpawnXRange, randSpawnXRange), 0f, spawnPositionZ);



        //Spawn Road *********************************************************************
        
        GameObject roadForCars = BarrierPool.SharedInstance.GetPooledRoadObject();
        if (roadForCars != null)
        {
            
            roadForCars.transform.position = spawnPos;
            roadForCars.transform.rotation = Quaternion.identity;
            roadForCars.SetActive(true);
            
        }
        

        //Spawn Car *******************************************************************
        GameObject barrierCar = BarrierPool.SharedInstance.GetPooledCarObject();
        if (barrierCar != null)
        {
            barrierCar.transform.position = spawnPos;
            
            if (rotateBarierForCorrectQueue)
            {
                barrierCar.transform.rotation = Quaternion.identity;
                rotateBarierForCorrectQueue = false;
            }
            else
            {
                barrierCar.transform.rotation = new Quaternion(0, 180, 0, 0);
                rotateBarierForCorrectQueue = true;
            }

            barrierCar.SetActive(true);
        }

    }

    
}
