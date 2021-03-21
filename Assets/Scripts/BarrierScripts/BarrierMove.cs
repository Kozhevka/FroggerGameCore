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

    //repeat lehht
    private Vector3 startPos;
    float repeatWight;

    //
    public bool moveLeftB = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //randomFloat = Random.Range(0f, 1f);
        //startPos = transform.position;
        //repeatWight = mainBarrier.GetComponent<BoxCollider>().size.x;
        //moveSpeed = Random.Range(minSpeed, maxSpeed);
        //
        //if (randomFloat > 0.5f) // rotate for forward move direction
        //{
        //    moveLeftB = true;
        //    transform.Rotate(0, 180, 0);
        //}
    }
    private void OnEnable()
    {
        randomFloat = Random.Range(0f, 1f);
        startPos = transform.position;
        repeatWight = mainBarrier.GetComponent<BoxCollider>().size.x;
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        if (randomFloat > 0.5f) // rotate for forward move direction
        {
            moveLeftB = true;
            transform.Rotate(0, 180, 0);
        }
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
