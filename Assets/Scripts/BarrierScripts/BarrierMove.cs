using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMove : MonoBehaviour
{

    public float moveSpeed = 3f;
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
        randomFloat = Random.Range(0f, 1f);
        startPos = transform.position;
        repeatWight = mainBarrier.GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (randomFloat > 0.5f)
            MoveLeft();
        else
            MoveRight();
    }

    void MoveLeft()
    {

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        moveLeftB = true;

        if (transform.position.x < startPos.x - repeatWight)
        {
            transform.position = startPos;
        }
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        moveLeftB = false;

        if (transform.position.x > startPos.x + repeatWight)
        {
            transform.position = startPos;
        }
    }
    
}
