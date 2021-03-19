using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 camepaPreferPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookAtPlayerPosition = playerPosition.position + camepaPreferPosition;
        transform.position = Vector3.Lerp(transform.position, lookAtPlayerPosition, moveSpeed);
    }
}
