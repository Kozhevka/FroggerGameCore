using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDeactivate : MonoBehaviour
{
    Transform player;
    float barrier = 4f;
    float spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerNextPosition").transform;
        spawnPos = GameObject.Find("BarrierSpawnManager").GetComponent<BarrierSpawn>().distanceToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.position.z - barrier) > this.transform.position.z
            || this.transform.position.z > (player.position.z + spawnPos - 1f))
        {
            gameObject.SetActive(false);
            
        }

    }
}
