using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //[SerializeField] float playerMoveSpeed = 0.025f;
    [SerializeField] float stepDistance;
    [SerializeField] Transform playerBody;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] GameObject barrierSpawnObject;
    BarrierSpawn barrierSpawnScript;

    


    
    public bool playerStatic = true;



    // Start is called before the first frame update
    void Start()
    {
        barrierSpawnScript = barrierSpawnObject.GetComponent<BarrierSpawn>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckIfStatic();

        if (playerStatic)
        {
            if (Input.GetKeyDown(KeyCode.W))
                MoveForward();

            if (Input.GetKeyDown(KeyCode.A))
                MoveLeft();

            if (Input.GetKeyDown(KeyCode.D))
                MoveRight();
        }

    }

    
    private void MoveRight()
    {
        float nextPosition = transform.position.x + stepDistance;
        transform.position = new Vector3(nextPosition, transform.position.y, transform.position.z);
    }

    private void MoveLeft()
    {
        float nextPosition = transform.position.x - stepDistance;
        transform.position = new Vector3(nextPosition, transform.position.y, transform.position.z);
    }

    private void CheckIfStatic()
    {
        if (transform.position == playerBody.position)
            playerStatic = true;
        else if (transform.position != playerBody.position)
            playerStatic = false;
    }

    public void MoveForward()
    {
        float nextPosition = transform.position.z + stepDistance;
        transform.position = new Vector3(transform.position.x, transform.position.y, nextPosition);
        barrierSpawnScript.SpawnOneRoad();
    }
}
