using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject ScoreText;
    public int UFOScore = 5;
    public int QuizScore = 10;
    public int ScoreT;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.GetComponent<TextMeshProUGUI>().text = "점수: " + ScoreT;
    }
}
