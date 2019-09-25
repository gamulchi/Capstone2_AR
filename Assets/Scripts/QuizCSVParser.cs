using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class QuizCSVParser : MonoBehaviour

{
    public TextAsset QuizCSV;
    public string AllText;
    public int CSVHeight;
    public int CSVWidth;
    public string[,] data;
   // public List<List<string>> data = new List<List<string>>();
    public List<QUIZ> QuizList = new List<QUIZ>();
    private int i=0;

    IEnumerator TestShow()
    {
        while (true)
        {
            if (i >= QuizList.Count)
            {
                i = 0;
            }
            GameObject.FindGameObjectWithTag("Canvas").transform.Find("Text").gameObject.GetComponent<Text>().text = QuizList[i].QuizText;

            i++;

            yield return new WaitForSeconds(2);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!QuizCSV)
        {
            QuizCSV = Resources.Load("Qu_iz") as TextAsset;
        }
        if (QuizCSV)
        {
            AllText = QuizCSV.text;
            data = new string[AllText.Split('\n').Length,AllText.Split('\n')[0].Split(',').Length];
            CSVHeight = AllText.Split('\n').Length;
            CSVWidth = AllText.Split('\n')[0].Split(',').Length;

            for (int i = 0; i < CSVHeight; i++)
            {
                for (int j = 0; j < CSVWidth; j++)
                {
                    print("i:" + i + "  j:" + j);
                    //data[i].Add(QuizCSV.text.Split('\n')[i].Split(',')[j]);
                    data[i,j] = AllText.Split('\n')[i].Split(',')[j];
                }
            }
        }
        for (int i = 1; i < CSVHeight; i++)
        {
            QUIZ q = new QUIZ
            {
                id = Convert.ToInt16(data[i,0]),
                QuizText = data[i,1],
                Answer = data[i,2],
                WrongAnswer1 = data[i,3],
                WrongAnswer2 = data[i,4]
            };
            QuizList.Add(q);
        }
        StartCoroutine(TestShow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class QUIZ
{
   public int id;
   public string QuizText;
   public string Answer;
   public string WrongAnswer1;
  public  string WrongAnswer2;

}

