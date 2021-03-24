using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_GameIsActive : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;


    ScoreCount scoreCountScript;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreCountScript = GameObject.Find("GameManager").GetComponent<ScoreCount>();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "Score: " + scoreCountScript.Score;
    }
    
}
