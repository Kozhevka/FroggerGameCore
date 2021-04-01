using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMoveBody : MonoBehaviour
{
    [SerializeField] GameObject playerNextPosition;
    [SerializeField] float smoothnesSpeed;
    bool playerStatic;
    bool playerOnBoat;
    PlayerMove playerMoveScript;

    
    // Start is called before the first frame update
    void Start()
    {
        PlayerMove playerMoveScript = playerNextPosition.GetComponent<PlayerMove>();
        playerStatic = playerMoveScript.playerStatic;
        playerOnBoat = playerMoveScript.playerOnBoat;
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        this.transform.position = Vector3.MoveTowards(this.transform.position, playerNextPosition.transform.position, smoothnesSpeed * Time.deltaTime);
    }

    public void LookAtDirection(Vector3 lookAt)
    {
        
        this.transform.rotation = Quaternion.Euler(0, lookAt.y, 0);
        
        
    }
}
