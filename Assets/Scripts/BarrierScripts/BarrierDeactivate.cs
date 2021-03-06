using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDeactivate : MonoBehaviour
{
    Transform player;
    
    float stepsToSpawn;
    float stepDistance;

    float distanceForwardPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerNextPosition").transform;
        stepDistance = GameObject.Find("PlayerNextPosition").GetComponent<PlayerMove>().stepDistance;
        stepsToSpawn = BarrierValueHolder.barrierValueHolder.stepsToSpawn;

        distanceForwardPlayer = (stepsToSpawn * stepDistance);// - 1f;


    }

    // Update is called once per frame
    void Update()
    {
        if (((player.position.z - (stepDistance * 3)) > this.transform.position.z) //*3 means 3 steps behinde
            || (this.transform.position.z > (player.position.z + distanceForwardPlayer+1))) //+1 means some distance forward. Without, road "can" deActivate after spawn
        {
            gameObject.SetActive(false);
            
        }

    }
}
