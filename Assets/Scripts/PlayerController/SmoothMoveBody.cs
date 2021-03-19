using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMoveBody : MonoBehaviour
{
    [SerializeField] GameObject playerNextPosition;
    [SerializeField] float smoothnesSpeed;
    bool playerStatic;
    PlayerMove playerMoveScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMove playerMoveScript = playerNextPosition.GetComponent<PlayerMove>();
        playerStatic = playerMoveScript.playerStatic;

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerStatic)
            LookToMovePoint();


        LookToMovePoint();
        transform.position = Vector3.MoveTowards(transform.position, playerNextPosition.transform.position, smoothnesSpeed * Time.deltaTime);
    }

    private void LookToMovePoint()
    {
        transform.LookAt(playerNextPosition.transform.position);
    }
}
