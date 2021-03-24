using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPool : MonoBehaviour
{
    public static BarrierPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject[] barrierToPoolList;
    public int amountToPool;


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
        
    }

    public GameObject GetPooledObject()
    {
        int barrierCurrentPool = amountToPool * barrierToPoolList.Length;
        
        int randomBarrierr = Random.Range(0, barrierCurrentPool - 1);
        if(!pooledObjects[randomBarrierr].activeInHierarchy)
        {
            return pooledObjects[randomBarrierr];
        }
        
        //Aslo we can add there other prefabs(if randomBarrier will be active.

        return null;//clean road
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
