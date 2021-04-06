using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Shop : MonoBehaviour
{
    [SerializeField] GameObject mainDataObj;
    MainData mainDataScript;


    [SerializeField] GameObject[] skinsList;
    [SerializeField] GameObject[] skinsPrices;

    [SerializeField] GameObject[] enviromentList;
    [SerializeField] GameObject[] enviromentPrices;

    


    // Start is called before the first frame update
    void Start()
    {
        mainDataScript = mainDataObj.GetComponent<MainData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
