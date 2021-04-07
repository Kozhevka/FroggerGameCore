using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnBoat : MonoBehaviour
{
    PlayerMove playerMoveScript;
    

    GameObject boatGameObject;
    

    float positionOnBoatXAxis;

    Vector3 downDir;
    // Start is called before the first frame update
    void Start()
    {

        playerMoveScript = this.gameObject.GetComponent<PlayerMove>();

    }

    public void NeedCheckGround(GameObject boat, float posOnBoat)
    {
        boatGameObject = boat;
        positionOnBoatXAxis = posOnBoat;
        //Debug.Log("needCheckGround");
    }

    // Update is called once per frame
    public void Update()
    {
        
        this.gameObject.transform.position = new Vector3(boatGameObject.transform.position.x, this.gameObject.transform.position.y, boatGameObject.transform.position.z) 
                                            + new Vector3(positionOnBoatXAxis, 0f, 0f);
        
    }
}
