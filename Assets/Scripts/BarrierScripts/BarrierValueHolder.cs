using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierValueHolder : MonoBehaviour
{
    public static BarrierValueHolder barrierValueHolder;
    public int stepsToSpawn;

    public float playerMoveBarriers { get; private set; }

    

    float stepDistance;

    private void Awake()
    {
        barrierValueHolder = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        stepDistance = GameObject.Find("PlayerNextPosition").
                        GetComponent<PlayerMove>().stepDistance;
        


        GameObject playerNextPosition = GameObject.Find("PlayerNextPosition");
        playerMoveBarriers = playerNextPosition.GetComponent<PlayerMove>().borderOfPlayzone;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
