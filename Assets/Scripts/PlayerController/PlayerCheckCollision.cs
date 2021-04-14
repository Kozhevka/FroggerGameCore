using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStatusEnum;


public class PlayerCheckCollision : MonoBehaviour
{
    GameStatusEnum gameStatusEnum;

    // Game manager (game status)
    GameObject gameManagerObject;
    


    // Player Manager (visual stuff)
    GameObject playerManagerObject;

    
    //EnviromentSkinEnum enviromentSkinEnumScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");

        gameStatusEnum = gameManagerObject.GetComponent<GameStatusEnum>();

        playerManagerObject = GameObject.Find("PlayerManager");
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier") && gameStatusEnum.gameStatus == GameStatus.GameIsActive)
        {
            
            gameManagerObject.GetComponent<UI_GameOver>().GameOver();
        
        }
    }
    


}
