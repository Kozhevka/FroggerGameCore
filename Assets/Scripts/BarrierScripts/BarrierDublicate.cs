using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDublicate : MonoBehaviour
{
    float distanceToDublicate;
    Vector3 placeWhereDublicate;

    [SerializeField] GameObject objectSample;

    BarrierMove barierMoveScript;
    
    void Awake()
    {
        //dublicate Road.  You add 1 prefab of road. Creating 2 additional road.
        float startPositionX = this.transform.position.x;
        float barrierLeght = objectSample.GetComponent<BoxCollider>().size.x;

        Vector3 leftDublicateSpawnPos = new Vector3((-(barrierLeght) + startPositionX), 0f, this.transform.position.z);
        Vector3 rightDublicateSpawnPos = new Vector3((barrierLeght + startPositionX), 0f, this.transform.position.z);
        

        //dublicate childRoad for barrier  
        GameObject leftBarrier1 = Instantiate(objectSample, leftDublicateSpawnPos, this.transform.rotation);
        leftBarrier1.transform.parent = this.gameObject.transform;

        
    }

}
