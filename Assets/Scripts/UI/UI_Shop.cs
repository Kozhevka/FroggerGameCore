using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Shop : MonoBehaviour
{

    MainData mainDataScript;


    [SerializeField] GameObject shopUI;
    [SerializeField] GameObject activateGameUI;
    [SerializeField] TextMeshProUGUI[] balanceViewer;
    


    [SerializeField] GameObject[] skinsList;
    [SerializeField] TextMeshProUGUI[] skinsPrices;
    [SerializeField] bool[] boughtSkins;
    int[] skinPricesInt;

    [SerializeField] GameObject[] enviromentList;
    [SerializeField] TextMeshProUGUI[] enviromentPrices;
    [SerializeField]  bool[] boughtEnviroment;
    int[] enviromentPricesInt;


    //For restart spawn onEnable;
    BarrierStartSpawn barrierStartSpawn;
    


    // Start is called before the first frame update
    void Start()
    {
        mainDataScript = MainData.mainDataScript;

        skinPricesInt = mainDataScript.skinPrices;
        
        enviromentPricesInt = mainDataScript.enviromentPrices;

        for (int i = 0; i < mainDataScript.boughtSkins.Length; i++)
        {
            boughtSkins[i] = mainDataScript.boughtSkins[i];
        }
        for (int i = 0; i < mainDataScript.boughtEnviroment.Length; i++)
        {
            boughtEnviroment[i] = mainDataScript.boughtEnviroment[i];
        }



        for (int i = 0; i < skinsPrices.Length; i++)
        {
            skinsPrices[i].text = "$ - " + skinPricesInt[i + 1];
        }
        for (int i = 0; i < enviromentPrices.Length; i++)
        {
            enviromentPrices[i].text = "$ - " + enviromentPricesInt[i + 1];
        }
        
    }


    public void ActivateSkinButton(int skinNumber)
    {
        if (boughtSkins[skinNumber])
        {
            //Debug.Log("Skin already bought");
            ActivateSkinGameObject(skinNumber);
        }
        else if (!boughtSkins[skinNumber])
        {
            if (mainDataScript.BuySkin(skinNumber))
            {
                ActivateSkinGameObject(skinNumber);
                skinsPrices[skinNumber - 1].gameObject.SetActive(false); // -1 means default(What havent price viever)
            }
            
            UpdateShopUI();
        }
            
  
    }


    void ActivateSkinGameObject(int skinNumber)
    {
        foreach (var item in skinsList)
        {
            item.SetActive(false);
        }
        skinsList[skinNumber].SetActive(true);
    }

    public void ActivateEnvButton(int envNumber)
    {
        if (boughtEnviroment[envNumber])
        {
            //Debug.Log("Skin already bought");
            ActivateEnvGameObject(envNumber);
        }
        else if (!boughtEnviroment[envNumber])
        {
            if (mainDataScript.BuyEnviroment(envNumber))
            {
                ActivateEnvGameObject(envNumber);
                enviromentPrices[envNumber - 1].gameObject.SetActive(false); // -1 means default(What havent price viever)
            }
            UpdateShopUI();
        }

    }

    void ActivateEnvGameObject(int envNumber)
    {
        foreach (var item in enviromentList)
        {
            item.SetActive(false);
        }

        enviromentList[envNumber].SetActive(true);
        //Restart spawn
        GameObject.Find("SkinShell").GetComponent<BarrierStartSpawn>().RestartSpawn();
    }


    public void DisableShopEnableStartUI()
    {
        shopUI.SetActive(false);
        activateGameUI.SetActive(true);
    }

    public void DisableStartUIEnableShop()
    {
        UpdateShopUI();

        activateGameUI.SetActive(false);
        shopUI.SetActive(true);
    }

    void UpdateBalance()
    {
        foreach (var item in balanceViewer)
        {
            item.text = "$: " + mainDataScript.Balance;
        }
    }

    
    //Can be useful for save-load progress.
    /*void HidePriceIfBought()
    {
        //Hide price if bought
        for (int i = 0; i < (boughtSkins.Length - 1); i++) // -1 means -Default what havent price;
        {
            if (boughtSkins[i + 1])
                skinsPrices[i].SetActive(false);
        }

        for (int i = 0; i < boughtEnviroment.Length - 1; i++)
        {
            if (boughtEnviroment[i + 1])
                enviromentPrices[i].SetActive(false);
        }
    }*/


    void UpdateShopUI()
    {
        UpdateBalance();
        //HidePriceIfBought();
    }

}
