using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentSkinEnumerator : MonoBehaviour
{
    
    public enum EnviromentSkinEnum
    {
        Default,
        Red
    }
    public EnviromentSkinEnum enviromentSkinEnum;

    void Start()
    {
        enviromentSkinEnum = EnviromentSkinEnum.Default;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
