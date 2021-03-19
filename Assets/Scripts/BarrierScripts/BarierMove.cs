using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarierMove : MonoBehaviour
{

    public float moveSpeed = 3f;
    float randomFloat;
    // Start is called before the first frame update
    void Start()
    {
        randomFloat = Random.Range(0f, 1f);
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
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
