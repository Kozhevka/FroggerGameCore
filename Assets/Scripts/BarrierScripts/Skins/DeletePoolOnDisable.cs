using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePoolOnDisable : MonoBehaviour
{
    [SerializeField] GameObject[] roadPoolLists;



    private void OnDisable()
    {
        foreach (var item in roadPoolLists)
        {
            item.GetComponent<RoadPool>().DeletePool();
        }
    }
}
