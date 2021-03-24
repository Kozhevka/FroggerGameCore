using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    

    [SerializeField] float score = 0;
    public float Score
    {
        get
        {
            return score;
        }
        private set
        {
            score = value;
        }
    }

    float scoreWithDifficultyValue = 1f;

    


    PlayerMove playerMoveScript;

    
    // Start is called before the first frame update
    void Start()
    {
        playerMoveScript = gameObject.GetComponent<PlayerMove>();
        

        scoreWithDifficultyValue = 1;
    }

    
    public void OneStepScore()
    {
        score += scoreWithDifficultyValue;
    }
    public void RestartScore()
    {
        Score = 0;
    }
}
