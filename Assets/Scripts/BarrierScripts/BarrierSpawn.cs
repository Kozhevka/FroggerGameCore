using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawn : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    PlayerMove playerMoveScript;

    [SerializeField] public GameObject[] bariers;
    [SerializeField] public GameObject[] ground;

    [SerializeField] float distanceToSpawn;
    float spawnZPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMoveScript = playerObject.GetComponent<PlayerMove>();
        
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
        Instantiate(bariers[0], spawnPos, Quaternion.identity);
        Debug.Log("pipiska");
    }

    
}
