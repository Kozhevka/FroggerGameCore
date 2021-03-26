using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMove : MonoBehaviour
{

    public float moveSpeed;
    float minSpeed = 1;
    float maxSpeed = 3;
    float randomFloat;
    [SerializeField] GameObject mainBarrier;
    [SerializeField] Transform thisPrefabTransform;

    //repeat lehht
    private Vector3 startPos;
    float repeatWight;

    //
    public bool moveLeftB = false;



    private void OnEnable()
    {
        startPos = this.transform.position;
    }


    private void Start() 
    {
        
        repeatWight = mainBarrier.GetComponent<BoxCollider>().size.x;
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }



    void Move()
    {
        
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        

        if (transform.position.x < startPos.x - repeatWight)
        {
            transform.position = startPos;
        }
        else if (transform.position.x > startPos.x + repeatWight)
        {
            transform.position = startPos;
        }
    }

    
    
}
