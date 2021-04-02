using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMove : MonoBehaviour
{

    public float moveSpeed;

    float borderOfPlayzone;
    float disableDistanceFromBorder = 10f;
    float sumOfDisableDistance;
    

    //
    public bool moveLeftB = false;

    private void Start()
    {
        GameObject playerNextPosition = GameObject.Find("PlayerNextPosition");
        borderOfPlayzone = playerNextPosition.GetComponent<PlayerMove>().borderOfPlayzone;

        sumOfDisableDistance = borderOfPlayzone + disableDistanceFromBorder;
    }


    // Update is called once per frame
    void Update()
    {
        Move();


    }

    private void FixedUpdate()
    {
        if (this.transform.position.x > sumOfDisableDistance 
            || this.transform.position.x < -sumOfDisableDistance)
                {
            this.gameObject.SetActive(false);
                }

    }



    void Move()
    {
        
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        
    }

    
    
}
