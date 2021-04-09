using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainData : MonoBehaviour
{
    public static MainData mainDataScript;
    
    public int Balance { get; private set; }
    [SerializeField] int balance;
    


    // skin[0] && buyedSkin[0]=true - mean that player bought [0] skin. We can use only bool but GameObject[] we can see what exactly;  
    public GameObject[] skins;
    public bool[] boughtSkins;
    public int[] skinPrices;

    public GameObject[] enviroment;
    public bool[] boughtEnviroment;
    public int[] enviromentPrices;
    // Start is called before the first frame update
    private void Awake()
    {
        mainDataScript = this;
    }

    void Start()
    {
        //Balance = 100;
    }

    // Update is called once per frame
    void Update()
    {
       // balance = Balance;
    }

    public void UpdateBalance(int gottedScore)
    {
        Balance += gottedScore;
    }

    public bool BuySkin(int skinNumber)
    {
        if(boughtSkins[skinNumber])
        {
            //Debug.LogError("Player already got that skin");
            return true;
        }
        else if (Balance < skinPrices[skinNumber])
        {
            Debug.LogError("Not enouch money");
            return false;
        }
        else if (Balance > skinPrices[skinNumber])
        {
            boughtSkins[skinNumber] = true;
            Balance -= skinPrices[skinNumber];
            //Debug.Log("Buying complete");
            return true;
        }

        return false;
    }

    public bool BuyEnviroment(int envNumber)
    {
        if (boughtEnviroment[envNumber])
        {
            //Debug.LogError("Player already got that enviroment");
            return true;
        }
        else if (Balance < enviromentPrices[envNumber])
        {
            Debug.LogError("Not enouch money");
            return false;
        }
        else if (Balance > enviromentPrices[envNumber])
        {
            boughtEnviroment[envNumber] = true;
            Balance -= enviromentPrices[envNumber];
            //Debug.Log("Buying complete");
            return true;
        }

        return false;
    }
}
