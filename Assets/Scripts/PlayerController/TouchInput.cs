using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    [SerializeField] GameObject playerMoveHolder;
    PlayerMove playerMoveScript;

    bool playerStatic;
    bool playerOnBoat;


    //Input.GetTouch --------------------------------------
    [Header("For touch input")]
    [SerializeField] Button upperButtonOnActiveGame;
    float upperButtonHeight;
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string direction;




    void Start()
    {
        playerMoveScript = playerMoveHolder.GetComponent<PlayerMove>();

        upperButtonHeight = upperButtonOnActiveGame.GetComponent<RectTransform>().rect.height;
    }
    
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerStatic = playerMoveScript.playerStatic;
        playerOnBoat = playerMoveScript.playerOnBoat;

        playerMoveScript.CheckIfStatic();

        
        if (playerStatic || playerOnBoat) //move input
        {
            TouchInputUpdate();
        }
        
    }

    private void TouchInputUpdate()
    {
        //TouchScreen input
        if (Input.touchCount > 0) // && ) 
        {
            theTouch = Input.GetTouch(0);
            bool touchContiniue;
            if (theTouch.position.y < Screen.height - upperButtonHeight)
            // && touch not ower ui
            {
                if (theTouch.phase == TouchPhase.Began)
                {
                    touchStartPosition = theTouch.position;
                    touchContiniue = true;
                }
                else if (theTouch.phase == TouchPhase.Ended)
                {
                    touchEndPosition = theTouch.position;

                    float x = touchEndPosition.x - touchStartPosition.x;
                    float y = touchEndPosition.y - touchStartPosition.y;

                    if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                    {
                        playerMoveScript.MoveForward();
                    }
                    else if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        if (x > 0)
                        {
                            playerMoveScript.MoveRight();
                        }
                        else if (x < 0)
                        {
                            playerMoveScript.MoveLeft();
                        }

                    }
                    else if (Mathf.Abs(y) > Mathf.Abs(x))
                    {
                        if (y > 0)
                        {
                            playerMoveScript.MoveForward();
                        }
                    }
                    touchContiniue = false;

                }
            }
        }

    }
}
