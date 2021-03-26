using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPool : MonoBehaviour
{
    public static BarrierPool SharedInstance;
    public List<GameObject> pooledCars;
    public List<GameObject> pooledRoads;
    
    [SerializeField] GameObject[] barrierCarsToPoolList;
    [SerializeField] GameObject roadToPoolList; //also we can create list for more variables
    public int amountCarToPool = 25;
    public int amountRoadToPool = 10;

    BarrierStartSpawn barrierStartSpawn;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Cars*******************************************************************

        pooledCars = new List<GameObject>();
        GameObject tmp;
        
        for (int i = 0; i < barrierCarsToPoolList.Length; i++)
        {
            for (int b = 0; b < amountCarToPool; b++)
            {
                tmp = Instantiate(barrierCarsToPoolList[i]);
                tmp.SetActive(false);
                pooledCars.Add(tmp);
            }
        }

        //Roads*******************************************************************
        pooledRoads = new List<GameObject>();
        GameObject rtmp;

        for (int i = 0; i < amountRoadToPool; i++)
        {
            rtmp = Instantiate(roadToPoolList);
            rtmp.SetActive(false);
            pooledRoads.Add(rtmp);
        }

        BarrierStartSpawn.StartGameSpawner.RestartSpawn();
    }

    public GameObject GetPooledCarObject()
    {
        int barrierCurrentPool = (amountCarToPool * barrierCarsToPoolList.Length)-1;
        
        int randomBarrierr = Random.Range(0, barrierCurrentPool);
        bool returnConfirm = false;

        while (!returnConfirm)
        {
            if (!pooledCars[randomBarrierr].activeInHierarchy)
            {
                returnConfirm = true;

                return pooledCars[randomBarrierr];
            }
            else
            {
                randomBarrierr = Random.Range(0, barrierCurrentPool);
            }
        }

        return null; //clean road
    }

    public GameObject GetPooledRoadObject()
    {
        for (int i = 0; i < amountRoadToPool; i++)
        {
            if (!pooledRoads[i].activeInHierarchy)
            {
                return pooledRoads[i];
            }
        }

        Debug.Log("not enough roads in pool");
        return null;

    }

    public void DeactivateAllPooledObjects()
    {
        foreach (var item in pooledCars)
        {
            item.SetActive(false);
        }
        foreach (var item in pooledRoads)
        {
            item.SetActive(false);
        }
    }
}
