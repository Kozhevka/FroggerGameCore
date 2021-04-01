using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierVievBorder : MonoBehaviour
{
    float borderOfPlayzone;

    PlayerMove playerMoveScript;
    

    [SerializeField] Transform leftBorder;
    [SerializeField] Transform rightBorder;

    void Start()
    {
        GameObject playerNextPosition = GameObject.Find("PlayerNextPosition");
        borderOfPlayzone = playerNextPosition.GetComponent<PlayerMove>().borderOfPlayzone
                            +   (playerNextPosition.GetComponent<PlayerMove>().stepDistance * 0.1f);

        leftBorder.transform.position = new Vector3(-borderOfPlayzone, 0.1f, this.transform.position.z);
        rightBorder.transform.position = new Vector3(borderOfPlayzone, 0.1f, this.transform.position.z);

    }
}
