using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectsSpawn : MonoBehaviour
{
    //Attach to main Spawn point in road

    [SerializeField] Transform[] onEnableSpawnPoints;

    [SerializeField] GameObject poolOfObjects;
    MovingObjectsPool movingObjectsPoolScript;

    [SerializeField] Vector2 minAndMaxSpeed;
    float speedOfthisRoad;

    int typeOfNextCar = 0;
    float waitTimeToNextSpawn = 0;
    float seconds;


    public void OnEnableSpawn()
    {
        speedOfthisRoad = Random.Range(minAndMaxSpeed.x, minAndMaxSpeed.y);
        //Debug.Log($"Speed of this road = {speedOfthisRoad}");
        // shoose type of Car


        for (int i = 0; i < onEnableSpawnPoints.Length; i++)
        {
            typeOfNextCar = PickNextCarAlgotytm();
            //Debug.Log($"type of next car = {typeOfNextCar}");
            //Debug.Log($"onEnable in moving object spawn point {onEnableSpawnPoints[i].transform.position}");
            SpawnOneObject(onEnableSpawnPoints[i].transform.position, typeOfNextCar);
        }
        StartCoroutine(SpawnNextCar(waitTimeToNextSpawn));
    }

    private void Awake()
    {
        movingObjectsPoolScript = poolOfObjects.GetComponent<MovingObjectsPool>();
    }


    private void Update()
    {
        
    }

    IEnumerator SpawnNextCar(float seconds)
    {
        //Debug.Log($"SpawnNextCar iEnumerator WaitForSeconds = {seconds}");
        SpawnOneObject(this.transform.position, typeOfNextCar);
        yield return new WaitForSeconds(seconds);
    }

    int PickNextCarAlgotytm()
    {
        
        int random = Random.Range(1, 10);
        //Debug.Log($"random = {random}");
        if (random < 4)
        {
            waitTimeToNextSpawn = 1;
            return 0; //small car
            
        }
        else if (random > 8)
        {
            waitTimeToNextSpawn = 2;
            return 2; //big car
        }
        else
        {
            waitTimeToNextSpawn = 1.5f;
            return 1; // medium car
        }
    }


    public void SpawnOneObject(Vector3 spawnPos, int typeOfCar)
    {
        

        GameObject barrierCar = movingObjectsPoolScript.GetPooledObject(typeOfCar);
        //Debug.Log($"barrier car name = {barrierCar.name}");

        if (barrierCar != null)
        {
            barrierCar.transform.position = spawnPos;

            barrierCar.transform.rotation = Quaternion.identity;

            barrierCar.GetComponent<BarrierMove>().moveSpeed = speedOfthisRoad;
            
            barrierCar.SetActive(true);
        }
        if (barrierCar == null)
            Debug.Log("Spawn one object NUll");
    }
}
