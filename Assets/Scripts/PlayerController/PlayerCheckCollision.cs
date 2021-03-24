using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCheckCollision : MonoBehaviour
{
    

    // Game manager (game status)
    GameObject gameManagerObject;
    


    // Player Manager (visual stuff)
    GameObject playerManagerObject;

    PlayerSkinEnum playerSkinEnumScript;
    EnviromentSkinEnum enviromentSkinEnumScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        
        

        playerManagerObject = GameObject.Find("PlayerManager");
        playerSkinEnumScript = playerManagerObject.GetComponent<PlayerSkinEnum>();
        enviromentSkinEnumScript = playerManagerObject.GetComponent<EnviromentSkinEnum>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("Game Over!");

            gameManagerObject.GetComponent<UI_GameOver>().GameOver();

        }
    }
    
}
