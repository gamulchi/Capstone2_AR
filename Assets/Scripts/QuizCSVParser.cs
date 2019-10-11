using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class QuizCSVParser : MonoBehaviour
    //캔버스에 달아놓은 스크립트,퀴즈 파싱과 퀴즈 표시 시간 제어
{
    #region 퀴즈 UI 요소들
    public TextAsset QuizCSV;
    public GameObject QuizText;
    public GameObject QuizIndex;
    public GameObject QuizBackground;
    public List<GameObject> AnswerButtons = new List<GameObject>();
    #endregion
    #region 퀴즈 CSV 파싱
    public string AllText;
    public int CSVHeight;
    public int CSVWidth;
    public string[,] data;
    public int x = 0;
    public List<int> Index = new List<int>();
    //몇번 퀴즈를 고를 것인지 랜덤으로 돌리는 함수
    // public List<List<string>> data = new List<List<string>>();
    public List<QUIZ> QuizList = new List<QUIZ>();
    public int KillingUfoCount = 0;
    public enum PlayState { NoQuiz,QuizStarted,QuizFinished}
    public PlayState CurrentPlayState=PlayState.NoQuiz;
    #endregion
    IEnumerator QuizUIManager()
    {
        while (true)
        {
            //while 쓸때는 EndofFrame()쓰기->while개많이 먹음
            yield return new WaitForEndOfFrame();
            //처음 startcorroutine으로 불러올때 while문 조건과 안맞으면 update에서 조건 맞아도 실행 안됨
            if (KillingUfoCount == 5 && CurrentPlayState == PlayState.NoQuiz)
            {
                //중간에 killingUFOCount 값 바뀌어도 한번 들어갔으므로 if문 전체 돌아감
                print("QUIZ UI COrroutine");
                if (QuizText.activeInHierarchy == false)
                {
                    QuizText.SetActive(true);
                }
                if (QuizIndex.activeInHierarchy == false)
                {
                    QuizIndex.SetActive(true);
                }
                if (QuizBackground.activeInHierarchy == false)
                {
                    QuizBackground.SetActive(true);
                }
                for (int i = 0; i < AnswerButtons.Count; i++)
                {
                    if (AnswerButtons[i].activeInHierarchy == false)
                    {
                        AnswerButtons[i].SetActive(true);
                    }
                }
                
                CurrentPlayState = PlayState.QuizStarted;

            }
        }
    }
    #region 퀴즈 관리하는 함수
    IEnumerator TestShow()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (QuizText.activeInHierarchy == true)
            {

                if (x >= QuizList.Count)
                {
                    x = 0;
                }
                QuizText.GetComponent<TextMeshProUGUI>().text = QuizList[x].QuizText;
                x++;
            }

        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Index.Clear();
        List<int> RandRand = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        print("rand count: " + RandRand.Count);
        for(int i = 0; i < RandRand.Count; i++)
        {
            int x= UnityEngine.Random.Range(0, RandRand.Count);
            print("i:" + i + " x:" + x + " value" + RandRand[x]);
            Index.Add(RandRand[x]);
            RandRand.RemoveAt(x);
        }
        #region 퀴즈 UI 요소들 찾기
        AnswerButtons.Clear();
        if (!QuizText)
        {
            QuizText = transform.Find("QuizText").gameObject;
        }
        if (!QuizIndex)
        {
            QuizIndex = transform.Find("QuizIndex").gameObject;
        }
        if (!QuizBackground)
        {
            QuizBackground = transform.Find("QuizBackground").gameObject;
        }
        foreach(Transform child in transform)
        {
            if (child.gameObject.tag == "Answer")
            {
                AnswerButtons.Add(child.gameObject);
            }
        }

        #endregion
        #region CSV 파싱 부분
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
        #endregion
        //StartCoroutine(TestShow());
        StartCoroutine(QuizUIManager());
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPlayState == PlayState.QuizFinished)
        {
            KillingUfoCount = 0;
        }
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

