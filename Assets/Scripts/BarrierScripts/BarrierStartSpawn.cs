using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierStartSpawn : MonoBehaviour
{
    public static BarrierStartSpawn StartGameSpawner;
    float stepDistance;
    float distanceToMainSpawn;

    [SerializeField] GameObject playerMoveObj;
    BarrierSpawn barrierSpawnScript;

    [SerializeField] GameObject[] barriers;

    private void Awake()
    {
        StartGameSpawner = this; 
    }

    void Start()
    {
        stepDistance = playerMoveObj.GetComponent<PlayerMove>().stepDistance;
        distanceToMainSpawn = this.gameObject.GetComponent<BarrierSpawn>().distanceToSpawn;

        
    }


    public void RestartSpawn()
    {
        
        for (int i = 1; i < distanceToMainSpawn/stepDistance+1; i++)
        {
            Vector3 spawnPos = new Vector3(0f, 0f, stepDistance * i);
            int pickedBarrier = Random.Range(0, barriers.Length);

            //Instantiate(barriers[pickedBarrier], spawnPos, Quaternion.identity);

            GameObject barrier = BarrierPool.SharedInstance.GetPooledObject();
            if (barrier != null)
            {
                barrier.transform.position = spawnPos;
                barrier.transform.rotation = Quaternion.identity;
                barrier.SetActive(true);
            }
        }
        


    }
}
