using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPool : MonoBehaviour
{
    public static BarrierPool SharedInstance;
    public List<GameObject> pooledObjects;
    
    public GameObject[] barrierToPoolList;
    public int amountToPool;

    BarrierStartSpawn barrierStartSpawn;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        
        for (int i = 0; i < barrierToPoolList.Length; i++)
        {
            for (int b = 0; b < amountToPool; b++)
            {
                tmp = Instantiate(barrierToPoolList[i]);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

        BarrierStartSpawn.StartGameSpawner.RestartSpawn();
    }

    public GameObject GetPooledObject()
    {
        int barrierCurrentPool = (amountToPool * barrierToPoolList.Length)-1;
        


        int randomBarrierr = Random.Range(0, barrierCurrentPool);
        bool returnConfirm = false;

        while (!returnConfirm)
        {
            if (!pooledObjects[randomBarrierr].activeInHierarchy)
            {
                returnConfirm = true;
                return pooledObjects[randomBarrierr];
            }
            else
            {
                randomBarrierr = Random.Range(0, barrierCurrentPool);
            }
        }

        
        
        //Aslo we can add there other prefabs(if randomBarrier will be active.

        return null; //clean road
    }

    public void DeactivateAllPooledObjects()
    {
        foreach (var item in pooledObjects)
        {
            item.SetActive(false);
        }
    }
}
