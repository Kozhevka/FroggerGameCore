using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TopScore : MonoBehaviour
{
    [SerializeField] GameObject topScoreUI;
    [SerializeField] GameObject startMenuUI;


    [SerializeField] TextMeshProUGUI[] top5ScoreRating;

    [SerializeField] int[] top5Scores;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < top5Scores.Length; i++)
        {
            top5Scores[i] = 0;
        }
    }

    

    public void GetNewResult(int newScore)
    {
        for (int i = 0; i < top5Scores.Length; i++)
        {
            if (newScore>top5Scores[i])
            {

                List<int> arrayLessValues = new List<int>();
                for (int b = i; b < top5Scores.Length; b++)
                {
                    arrayLessValues.Add(top5Scores[b]);
                }
                top5Scores[i] = newScore;

                int c = 0; ///additional index for "for"
                for (int b = i+1; b < top5Scores.Length; b++, c++)
                {
                    top5Scores[b] = arrayLessValues[c];
                    if (i == 4)
                        break;
                }

                UpdateList();
                break;
            }

        }
    }

    void UpdateList()
    {
        for (int i = 0; i < top5ScoreRating.Length; i++)
        {
            if (top5Scores[i] == 0)
                top5ScoreRating[i].gameObject.SetActive(false);
            if (top5Scores[i] > 0)
                top5ScoreRating[i].gameObject.SetActive(true);
            top5ScoreRating[i].text = $"{i + 1}: Score {top5Scores[i]}";
        }
    }



    public void TopRatingButton()
    {
        UpdateList();
        startMenuUI.SetActive(false);
        topScoreUI.SetActive(true);
    }

    public void ExitTopRatingButton()
    {
        startMenuUI.SetActive(true);
        topScoreUI.SetActive(false);
        
    }
}
