using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectsSpawn : MonoBehaviour
{
    //Attach to main Spawn point in road

    [SerializeField] Transform repeatSpawnPoint;
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
            int random = Random.Range(0, 1);

            if(random==0)
            {
                typeOfNextCar = PickNextCarAlgotytm();

                SpawnOneObject(onEnableSpawnPoints[i].transform.position, typeOfNextCar);
            }
            
        }
        StartCoroutine(SpawnNextCar(waitTimeToNextSpawn));
    }

    private void Awake()
    {
        movingObjectsPoolScript = poolOfObjects.GetComponent<MovingObjectsPool>();
    }


    void RepeatingSpawn()
    {
        SpawnOneObject(repeatSpawnPoint.position, typeOfNextCar);
        StartCoroutine(SpawnNextCar(waitTimeToNextSpawn));
    }

    IEnumerator SpawnNextCar(float seconds)
    {
        //Debug.Log($"SpawnNextCar iEnumerator WaitForSeconds = {seconds}");
        yield return new WaitForSeconds(seconds);
        RepeatingSpawn();
    }

    int PickNextCarAlgotytm()
    {
        
        int random = Random.Range(1, 10);
        //Debug.Log($"random = {random}");
        if (random < 4)
        {
            waitTimeToNextSpawn = 3f;
            return 0; //small car
            
        }
        else if (random > 8)
        {
            waitTimeToNextSpawn = 4.5f;
            return 2; //big car
        }
        else
        {
            waitTimeToNextSpawn = 6f;
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

            //barrierCar.transform.rotation = Quaternion.identity;

            barrierCar.GetComponent<BarrierMove>().moveSpeed = speedOfthisRoad;
            
            barrierCar.SetActive(true);
        }
        if (barrierCar == null)
            Debug.Log("Spawn one object NUll");
    }
}
