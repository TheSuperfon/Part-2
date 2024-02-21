using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //remembered this from week 6



public class Score : MonoBehaviour
{
    public TextMeshProUGUI HighScore;
    public float ActualScore;
    public float ThisMulitplier;



    // Start is called before the first frame update
    void Start()
    {
        HighScore = GetComponent<TextMeshProUGUI>();
        ActualScore = 0;
    }


    public void ScoreMultiples(float Multiplier)
    {
        ThisMulitplier = Multiplier;
        
        
    }

    public void ScoreUpdates(float updateScore)
    {
        ActualScore += (1*ThisMulitplier);
        
        
    }



    // Update is called once per frame
    void Update()
    {
        HighScore.text = ActualScore.ToString();
    }
}
