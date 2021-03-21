using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDublicate : MonoBehaviour
{
    float distanceToDublicate;
    Vector3 placeWhereDublicate;

    [SerializeField] GameObject objectSample;

    BarrierMove barierMoveScript;
    // Start is called before the first frame update
    void Awake()
    {
        //dublicate Road.  You add 1 prefab of road. Creating 2 additional road.
        float startPositionX = transform.position.x;
        float barrierLeght = objectSample.GetComponent<BoxCollider>().size.x;

        Vector3 leftDublicateSpawnPos = new Vector3((-(barrierLeght) + startPositionX), 0f, transform.position.z);
        Vector3 rightDublicateSpawnPos = new Vector3(((barrierLeght) + startPositionX), 0f, transform.position.z);

        //dublicate childRoad for barrier  
        GameObject leftBarrier = Instantiate(objectSample, leftDublicateSpawnPos, Quaternion.identity);
        leftBarrier.transform.parent = gameObject.transform;
        //GameObject rightBarrier = Instantiate(objectSample, rightDublicateSpawnPos, Quaternion.identity);
        //rightBarrier.transform.parent = gameObject.transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
