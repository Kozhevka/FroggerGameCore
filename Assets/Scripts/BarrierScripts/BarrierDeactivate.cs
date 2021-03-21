using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDeactivate : MonoBehaviour
{
    Transform player;
    float barrier = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerNextPosition").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.position.z - barrier) > transform.position.z)
            gameObject.SetActive(false);
    }
}
