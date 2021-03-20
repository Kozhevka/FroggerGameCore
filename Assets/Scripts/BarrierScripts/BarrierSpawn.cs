using System;
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

    [SerializeField] float distanceToSpawn;
    float spawnZPosition;

    
    

    
    // Start is called before the first frame update
    void Start()
    {
        playerMoveScript = playerObject.GetComponent<PlayerMove>();

        barrierDublicateScript = GetComponent<BarrierDublicate>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0f, 0f, playerObject.transform.position.z);

        spawnZPosition = transform.position.z + distanceToSpawn;
    }

    public void SpawnOneRoad()
    {
        Vector3 spawnPos = new Vector3(0f, 0f, spawnZPosition);
        int pickedBarrier = 0;
        Instantiate(barriers[pickedBarrier], spawnPos, Quaternion.identity);

    }

    
}
