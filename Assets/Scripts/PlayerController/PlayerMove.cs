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
    GameManagerMain mainGameManagerScript;

    //[SerializeField] GameObject barrierSpawnObject;


    public readonly float borderOfPlayzone = 10f;

    

    private Transform thisTransform;

    GameStatusEnum gameStatusEnum;
    GameObject gameManagerObject;

    SmoothMoveBody smoothMoveBodyScript;

    public bool playerStatic = true;
    public bool playerOnBoat = false;

    float distanceToSpawn;

    //Raycast-----------------------------------------
    PlayerOnBoat playerOnBoatScript;
    float distanceToCheck = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
       

        gameManagerObject = GameObject.Find("GameManager");

        mainGameManagerScript = gameManagerObject.GetComponent<GameManagerMain>();

        

        gameStatusEnum = gameManagerObject.GetComponent<GameStatusEnum>();

        smoothMoveBodyScript = playerBody.GetComponent<SmoothMoveBody>();
        

        playerOnBoatScript = this.gameObject.GetComponent<PlayerOnBoat>();

    }
    private void OnEnable()
    {
        thisTransform = this.gameObject.GetComponent<Transform>(); //optimization step;
    }

    // Update is called once per frame
    void Update()
    {

        CheckIfStatic();

        if (gameStatusEnum.gameStatus == GameStatus.GameIsActive)
        {
            if (playerStatic || playerOnBoat) //move input
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    smoothMoveBodyScript.LookAtDirection(new Vector3(0,0,0));
                    MovePlayer(0, stepDistance, true);
                }
                    


                else if (Input.GetKeyDown(KeyCode.A)) //else for disable diogonale move
                {
                    smoothMoveBodyScript.LookAtDirection(new Vector3(0, -90, 0));
                    MovePlayer(-stepDistance/2, 0, false);
                }
                    

                else if (Input.GetKeyDown(KeyCode.D))
                {
                    smoothMoveBodyScript.LookAtDirection(new Vector3(0, 90, 0));
                    MovePlayer(stepDistance/2, 0, false);
                }
                    

            }
        }
    }

    private void CheckIfStatic()
    {
        if (thisTransform.position == playerBody.position)
            playerStatic = true;
        else if (thisTransform.position != playerBody.position)
            playerStatic = false;
    }

    private void MovePlayer(float sideStepDistance, float forwardStepDistance, bool forwardMove)
    {
        float nextPosition = (Mathf.Round((thisTransform.position.z / stepDistance)) * stepDistance) + stepDistance; //nextPosition can / 2 int(stepDistance)
        
        

        thisTransform.position = new Vector3(thisTransform.position.x + sideStepDistance, thisTransform.position.y, thisTransform.position.z + forwardStepDistance);

        if (forwardMove)
        {
            mainGameManagerScript.PlayerMadeStepForward(thisTransform.position.z);

        }

        RaycastCheckGround();
        
    }

    private void RaycastCheckGround()
    {
        //Raycast for check ground tag ************************************************************************************************************
        RaycastHit hit;
        Physics.Raycast(this.transform.position, Vector3.down, out hit, distanceToCheck);

        //Debug.Log($"Player stay on: {hit.transform.gameObject.tag}");


        if (hit.transform == null)
            Debug.Log("Raycast hit nothin"); 
        else if (hit.transform.tag == "Boat")
        {
            playerOnBoat = true;
            float positionOnBoatXAxis = hit.point.x - hit.transform.position.x;
            BarrierMove barrierMoveScript = hit.transform.gameObject.GetComponent<BarrierMove>();
            playerOnBoatScript.enabled = true;
            playerOnBoatScript.NeedCheckGround(hit.transform.gameObject, positionOnBoatXAxis);
        }
        else if (hit.transform.tag == "Road")
        {
            playerOnBoatScript.enabled = false;
            //gameManagerObject.GetComponent<UI_GameOver>().GameOver();
            //Debug.Log("Road");
        }
        else if (hit.transform.tag == "Tree")
        {
            playerOnBoatScript.enabled = false;
            //gameManagerObject.GetComponent<UI_GameOver>().GameOver();
            //Debug.Log("Tree");
        }
        else if (hit.transform.tag == "Water")
        {
            playerOnBoatScript.enabled = false;
            gameManagerObject.GetComponent<UI_GameOver>().GameOver();
            //Debug.Log("Water");
        }
        



    }

    private void LateUpdate()
    {
        if(thisTransform.position.x < -borderOfPlayzone
            || thisTransform.position.x > borderOfPlayzone)
        {
            gameManagerObject.GetComponent<UI_GameOver>().GameOver();
        }
    }


}
