using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatusEnum;

public class PlayerMove : MonoBehaviour
{
    //[SerializeField] float playerMoveSpeed = 0.025f;
    public float stepDistance;
    [SerializeField] Transform playerBody;
    private Vector3 velocity = Vector3.zero;
    ScoreCount scoreCountScript;

    [SerializeField] GameObject barrierSpawnObject;
    BarrierSpawn barrierSpawnScript;

    [SerializeField] float borderOfPlayzone;

    private Transform thisTransform;

    GameStatusEnum gameStatusEnum;


    public bool playerStatic = true;



    float distanceToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        barrierSpawnScript = barrierSpawnObject.GetComponent<BarrierSpawn>();

        scoreCountScript = GameObject.Find("GameManager").GetComponent<ScoreCount>();

        

        gameStatusEnum = GameObject.Find("GameManager").GetComponent<GameStatusEnum>();

        distanceToSpawn = GameObject.Find("BarrierSpawnManager").GetComponent<BarrierSpawn>().distanceToSpawn;
    }
    private void OnEnable()
    {
        thisTransform = this.gameObject.GetComponent<Transform>(); //optimization step;
    }

    // Update is called once per frame
    void Update()
    {

        CheckIfStatic();

        if (playerStatic && gameStatusEnum.gameStatus == GameStatus.GameIsActive) //move input
        {
            if (Input.GetKeyDown(KeyCode.W))
                MoveForward();

            else if (Input.GetKeyDown(KeyCode.A)) //else for disable diogonale move
                MoveLeft();

            else if (Input.GetKeyDown(KeyCode.D))
                MoveRight();

        }
    }


    private void MoveRight()
    {
        if (thisTransform.position.x < borderOfPlayzone)
        {
            float nextPosition = thisTransform.position.x + stepDistance;
            thisTransform.position = new Vector3(nextPosition, thisTransform.position.y, thisTransform.position.z);
        }
    }

    private void MoveLeft()
    {
        if (thisTransform.position.x > -borderOfPlayzone)
        {
            float nextPosition = thisTransform.position.x - stepDistance;
            thisTransform.position = new Vector3(nextPosition, thisTransform.position.y, thisTransform.position.z);
        }
    }

    private void CheckIfStatic()
    {
        if (thisTransform.position == playerBody.position)
            playerStatic = true;
        else if (thisTransform.position != playerBody.position)
            playerStatic = false;
    }

    public void MoveForward()
    {
        float nextPosition = thisTransform.position.z + stepDistance;
        thisTransform.position = new Vector3(thisTransform.position.x, thisTransform.position.y, nextPosition);

        barrierSpawnScript.SpawnOneRoad(thisTransform.position.z + distanceToSpawn - stepDistance);

        scoreCountScript.OneStepScore();
    }
}
