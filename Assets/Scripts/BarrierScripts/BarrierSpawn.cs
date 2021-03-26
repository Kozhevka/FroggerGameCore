using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawn : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    PlayerMove playerMoveScript;
    BarrierDublicate barrierDublicateScript;
    
    

    [SerializeField] GameObject[] barriers;
    [SerializeField] GameObject[] ground;

    public float distanceToSpawn = 30f;
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
        int pickedBarrier = Random.Range(0, barriers.Length);

        //Instantiate(barriers[pickedBarrier], spawnPos, Quaternion.identity);

        GameObject barrier = BarrierPool.SharedInstance.GetPooledObject();
        if (barrier != null)
        {
            barrier.transform.position = spawnPos;
            


            if (rotateBarierForCorrectQueue)
            {
                barrier.transform.rotation = Quaternion.identity;
                rotateBarierForCorrectQueue = false;
            }
            else
            {
                barrier.transform.rotation = new Quaternion(0, 180, 0, 0);
                rotateBarierForCorrectQueue = true;
            }

            barrier.SetActive(true);
        }

    }

    
}
