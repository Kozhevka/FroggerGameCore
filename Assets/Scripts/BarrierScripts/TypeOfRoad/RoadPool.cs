using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPool : MonoBehaviour
{
    
    List<GameObject> pooledCars;
    List<GameObject> pooledRoads;
    
    //[SerializeField] GameObject[] barrierCarsToPoolList;
    [SerializeField] GameObject roadToPoolList; //also we can create list for more variables
    //public int amountCarToPool = 25;
    public int amountRoadToPool = 10;

    [SerializeField] GameObject skinHolder;

   
    
    // Start is called before the first frame update
    void Start()
    {

        
        pooledRoads = new List<GameObject>();
        GameObject rtmp;

        for (int i = 0; i < amountRoadToPool; i++)
        {
            
            rtmp = Instantiate(roadToPoolList);
            rtmp.GetComponent<MovingObjectsPool>().CreateMovingPool();
            rtmp.SetActive(false);
            pooledRoads.Add(rtmp);
        }

        
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

    public void DeactivateAllPooledRoads()
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
