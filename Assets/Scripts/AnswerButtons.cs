using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtons : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TouchButton()
    {
        if (this.gameObject == transform.parent.gameObject.GetComponent<QuizCSVParser>().RightAnswerButton)
        {
            if (transform.parent.gameObject.GetComponent<QuizCSVParser>().CurrentPlayState == QuizCSVParser.PlayState.QuizStarted)
            {
                transform.parent.gameObject.GetComponent<QuizCSVParser>().KillingUfoCount = 0;
                transform.parent.gameObject.GetComponent<QuizCSVParser>().CurrentPlayState = QuizCSVParser.PlayState.QuizFinished;
                GameObject.Find("ScoreCanvas").GetComponent<Score>().ScoreT += 10;
                print("CLICKED RIGHT ANSWER");
            }
        }
    }
    
}
