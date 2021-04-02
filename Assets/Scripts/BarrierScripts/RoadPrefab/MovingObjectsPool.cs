using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectsPool : MonoBehaviour
{
    
    [SerializeField] List<GameObject> pooledSmallObj;
    [SerializeField] List<GameObject> pooledMediumObj;
    [SerializeField] List<GameObject> pooledBigObj;
    

    

    [Header("List of objects")]
    [SerializeField] GameObject smallObject;
    [SerializeField] GameObject mediumObject;
    [SerializeField] GameObject bigObject;


     int amountObjectsToPool = 10;

    

    public void CreateMovingPool()
    {
        
        //Small objects
        pooledSmallObj = new List<GameObject>();
        GameObject poolSO;

        for (int i = 0; i < amountObjectsToPool; i++)
        {
            
            poolSO = Instantiate(smallObject);
            TransformParendAndRotation(poolSO.transform);
            poolSO.SetActive(false);
            pooledSmallObj.Add(poolSO);
        }

        //Medium objects
        pooledMediumObj = new List<GameObject>();
        GameObject poolMO;

        for (int i = 0; i < amountObjectsToPool; i++)
        {

            poolMO = Instantiate(mediumObject);
            TransformParendAndRotation(poolMO.transform);
            poolMO.SetActive(false);
            pooledMediumObj.Add(poolMO);
        }

        //Small objects
        pooledBigObj = new List<GameObject>();
        GameObject poolBO;

        for (int i = 0; i < amountObjectsToPool; i++)
        {

            poolBO = Instantiate(bigObject);
            TransformParendAndRotation(poolBO.transform);
            poolBO.SetActive(false);
            pooledBigObj.Add(poolBO);
        }

        
    }

    void TransformParendAndRotation(Transform gameObj)
    {
        gameObj.transform.parent = this.gameObject.transform;
        gameObj.transform.rotation = Quaternion.identity;
        
    }

    public GameObject GetPooledObject(int arrayInt) //0-small 1-medium 2-big
    {
        //Debug.Log($"Try to GetOPooledObject = {arrayInt}");
        if (arrayInt == 0)
        {
            
            for (int i = 0; i < amountObjectsToPool; i++)
            {

                if (!pooledSmallObj[i].activeInHierarchy)
                {
                    return pooledSmallObj[i];

                }
            }
            
        }
        else if (arrayInt == 1)
        {
            for (int i = 0; i < amountObjectsToPool; i++)
            {

                if (!pooledMediumObj[i].activeInHierarchy)
                {
                    return pooledMediumObj[i];

                }
            }
        }
        else //if (arrayInt == 2)
        {
            for (int i = 0; i < amountObjectsToPool; i++)
            {

                if (!pooledBigObj[i].activeInHierarchy)
                {
                    return pooledBigObj[i];

                }
            }
        }
        
        return null;
    }

    public void DeactivateAllPooledObjects()
    {
        foreach (var item in pooledSmallObj)
        {
            item.SetActive(false);
        }
        foreach (var item in pooledMediumObj)
        {
            item.SetActive(false);
        }
        foreach (var item in pooledBigObj)
        {
            item.SetActive(false);
        }
    }
}
