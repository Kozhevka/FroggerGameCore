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

    

    int typeOfNextCar = 0;
    float waitTimeToNextSpawn = 0;
    float seconds;

    bool didThatAStatic = false;

    float speedOfthisRoad;
    // Multiplier Road Speed
    [Header("RoadSpeed = rand_MinMaxSpeed + (spdMultiplier * score)")]
    float score;
    [SerializeField] float spdMultiplier = 0.01f;
    [SerializeField] Vector2 minAndMaxSpeed;

    [SerializeField] float timeWaitAfterSmall = 2f;
    [SerializeField] float timeWaitAfterMedium = 3f;
    [SerializeField] float timeWaitAfterBig = 4f;

    private void Awake()
    {
        movingObjectsPoolScript = poolOfObjects.GetComponent<MovingObjectsPool>();

        score = GameObject.Find("GameManager").GetComponent<ScoreCount>().Score;
        speedOfthisRoad = (Random.Range(minAndMaxSpeed.x, minAndMaxSpeed.y)) + (spdMultiplier * score);
    }

    public void OnEnableSpawn()
    {

        //Debug.Log($"Speed of this road = {speedOfthisRoad}");



        for (int i = 0; i < onEnableSpawnPoints.Length; i++)
        {
            int random = Random.Range(0, 2);

            if (random == 0)
            {
                typeOfNextCar = PickNextCarAlgotytm();

                SpawnOneObject(onEnableSpawnPoints[i].transform.position, typeOfNextCar);
            }

        }
        StartCoroutine(SpawnNextCar(waitTimeToNextSpawn));
    }

    void RepeatingSpawn()
    {
        if (!didThatAStatic)
        {
            typeOfNextCar = PickNextCarAlgotytm();
            SpawnOneObject(repeatSpawnPoint.position, typeOfNextCar);
            StartCoroutine(SpawnNextCar(waitTimeToNextSpawn));
        }
    }

    IEnumerator SpawnNextCar(float seconds)
    {
        //Debug.Log($"SpawnNextCar iEnumerator WaitForSeconds = {seconds}");
        yield return new WaitForSeconds(seconds);
        RepeatingSpawn();
    }

    int PickNextCarAlgotytm() // shoose type of Car
    {
        
        int random = Random.Range(1, 10);
        //Debug.Log($"random = {random}");
        if (random <= 4)
        {
            waitTimeToNextSpawn = timeWaitAfterSmall;
            return 0; //small car
            
        }
        else if (random >= 8)
        {
            waitTimeToNextSpawn = timeWaitAfterMedium;
            return 2; //big car
        }
        else
        {
            waitTimeToNextSpawn = timeWaitAfterBig;
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

            if (barrierCar.TryGetComponent<BarrierMove>(out var barrierCarScript))
                {
                barrierCarScript.moveSpeed = speedOfthisRoad;
                
                
                //Debug.Log("Barrier move gotten");
                }
            else
            {
                //Debug.Log("Barrier move is static");
                didThatAStatic = true;
            }

            
            barrierCar.SetActive(true);
        }
        //if (barrierCar == null)
        //    Debug.Log("Spawn one object NULL");
    }
}
