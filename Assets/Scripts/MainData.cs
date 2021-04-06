using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainData : MonoBehaviour
{

    
    public int Balance { get; private set; }

    


    // skin[0] && buyedSkin[0]=true - mean that player bought [0] skin. We can use only bool but GameObject[] we can see what exactly;  
    public GameObject[] skins;
    [SerializeField] List<bool> boughtSkins;
    [SerializeField] int[] skinPrices;

    public GameObject[] enviroment;
    [SerializeField] List<bool> boughtEnviroment;
    [SerializeField] int[] enviromentPrices;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            boughtSkins.Add(false);
        }
        for (int i = 0; i < enviroment.Length; i++)
        {
            boughtEnviroment.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateBalance(int gottedScore)
    {
        Balance += gottedScore;
    }

    void BuySkin(int skinNumber)
    {
        if(!boughtSkins[skinNumber])
        {
            Debug.LogError("Player already got that skin");
        }
        else if (Balance < skinPrices[skinNumber])
        {
            Debug.LogError("Not enouch money");
        }
        else if (Balance > skinPrices[skinNumber])
        {
            boughtSkins[skinNumber] = true;
            Balance -= skinPrices[skinNumber];
            Debug.Log("Buying complete");
        }
        
        
    }

    void BuyEnviroment(int envNumber)
    {
        if (!boughtEnviroment[envNumber])
        {
            Debug.LogError("Player already got that enviroment");
        }
        else if (Balance < enviromentPrices[envNumber])
        {
            Debug.LogError("Not enouch money");
        }
        else if (Balance > enviromentPrices[envNumber])
        {
            boughtEnviroment[envNumber] = true;
            Balance -= enviromentPrices[envNumber];
            Debug.Log("Buying complete");
        }
        

    }
}
