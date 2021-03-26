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
                MovePlayer(0, stepDistance, true);

            else if (Input.GetKeyDown(KeyCode.A)) //else for disable diogonale move
                MovePlayer(-stepDistance, 0, false);
            
            else if (Input.GetKeyDown(KeyCode.D))
                MovePlayer(stepDistance, 0, false);

        }
    }

    private void MovePlayer(float sideStepDistance, float forwardStepDistance, bool forwardMove)
    {
        float nextPosition = thisTransform.position.z + stepDistance;
        thisTransform.position = new Vector3(thisTransform.position.x + sideStepDistance, thisTransform.position.y, thisTransform.position.z + forwardStepDistance);

        if (forwardMove)
        {
            barrierSpawnScript.SpawnOneRoad(thisTransform.position.z + distanceToSpawn - stepDistance);
            scoreCountScript.OneStepScore();
        }
    }

    private void CheckIfStatic()
    {
        if (thisTransform.position == playerBody.position)
            playerStatic = true;
        else if (thisTransform.position != playerBody.position)
            playerStatic = false;
    }

}
