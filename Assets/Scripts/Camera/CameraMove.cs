using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatusEnum;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 camepaPreferPosition;

    [SerializeField] float selfMoveSpeed;

    [SerializeField] float distanceToFail;  //if player not fast enouch
    [SerializeField] float distanceToFollow;//if player too fast


    Vector3 startPosition;
    UI_GameOver uiGameOverScript;

    GameStatusEnum gameStatusEnum;
    // Start is called before the first frame update
    void Start()
    {
        gameStatusEnum = GameObject.Find("GameManager").GetComponent<GameStatusEnum>();
        uiGameOverScript = GameObject.Find("GameManager").GetComponent<UI_GameOver>();
        startPosition = this.transform.position;
    }

    private void Update()
    {
        if (gameStatusEnum.gameStatus == GameStatus.GameIsActive)
            this.transform.position += Vector3.forward * selfMoveSpeed * Time.deltaTime; //difficulty movement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStatusEnum.gameStatus == GameStatus.StartMenu) //Move to starp point
            this.transform.position = startPosition;


        if (gameStatusEnum.gameStatus == GameStatus.GameIsActive)
        {
            Vector3 lookAtPlayerPosition = playerPosition.position + camepaPreferPosition;
            if (this.transform.position.z < playerPosition.position.z - distanceToFollow)
                transform.position = Vector3.Lerp(transform.position, lookAtPlayerPosition, moveSpeed); //follow player

            //Left RightMove Folow
            Vector3 cameraXposition = new Vector3(playerPosition.position.x + camepaPreferPosition.x,
                                                  this.transform.position.y,
                                                  this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, cameraXposition, moveSpeed);

            //EndGame
            if (playerPosition.position.z + distanceToFail < this.transform.position.z)
                uiGameOverScript.GameOver();
        }
    }
}
