using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject UFOManager;
    public GameObject HappyEnding;
    public GameObject BadEnding;
    public GameObject PauseButton;
    public GameObject PauseCanvas;
    public enum EndingState {GameNotStart,GamePlaying,HappyEnding,BadEnding};
    public EndingState CurrentEndingState = EndingState.GameNotStart;
    private bool StateTrueFalse;
    // Start is called before the first frame update
    public float EndingUIWaitTime = 3f;
    //코루틴으로 바꾸는 게 낫나???
    IEnumerator EndingMgrCoroutine()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitUntil(()=>StateTrueFalse);
            //StateTrueFalse==true일때만 작동되는 람다식            
            if (CurrentEndingState!=EndingState.GameNotStart)
            {
                print("IN")
;
                switch (CurrentEndingState)
                {
                    case EndingState.GamePlaying:
                        if (Time.timeScale != 1)
                        {
                            Time.timeScale=1;
                        }
                        break;
                    case EndingState.HappyEnding:
                        if (Time.timeScale != 0)
                        {
                            Time.timeScale = 0;
                        }
                        if (HappyEnding.activeInHierarchy == false)
                        {
                            HappyEnding.SetActive(true);
                        }
                        yield return new WaitForSecondsRealtime(EndingUIWaitTime);
                        if (PauseCanvas.activeInHierarchy == false)
                        {
                            PauseCanvas.SetActive(true);
                            foreach (Transform child in PauseCanvas.transform)
                            {
                                if (child.gameObject.name == "Continue_But" && child.gameObject.activeInHierarchy == true)
                                {
                                    child.gameObject.SetActive(false);
                                }
                                if (child.gameObject.name == "Pause_Text" && child.gameObject.activeInHierarchy == true)
                                {
                                    child.gameObject.SetActive(false);
                                }
                            }
                        }
                        if (PauseButton.activeInHierarchy == true)
                        {
                            PauseButton.SetActive(false);
                        }
                        break;
                    case EndingState.BadEnding:
                        if (Time.timeScale != 0)
                        {
                            Time.timeScale = 0;
                        }
                        if (BadEnding.activeInHierarchy == false)
                        {
                            BadEnding.SetActive(true);
                        }
                        yield return new WaitForSecondsRealtime(EndingUIWaitTime);
                        if (PauseCanvas.activeInHierarchy == false)
                        {
                            PauseCanvas.SetActive(true);
                            foreach (Transform child in PauseCanvas.transform)
                            {
                                if (child.gameObject.name == "Continue_But" && child.gameObject.activeInHierarchy == true)
                                {
                                    child.gameObject.SetActive(false);
                                }
                                if (child.gameObject.name == "Pause_Text" && child.gameObject.activeInHierarchy == true)
                                {
                                    child.gameObject.SetActive(false);
                                }
                            }
                        }
                        if (PauseButton.activeInHierarchy == true)
                        {
                            PauseButton.SetActive(false);
                        }
                        break;
                        
                }
                
            }
            else
            {
                if (Time.timeScale != 0)
                {
                    Time.timeScale = 0;

                }
            }
        }
    }
    void Start()
    {
        if (!PauseButton)
        {
            PauseButton = transform.Find("PauseButton").gameObject;
        }
        if (!PauseCanvas)
        {
            PauseCanvas = GameObject.Find("Pause_Canvas");
        }
        if (!UFOManager)
        {
            UFOManager = GameObject.FindGameObjectWithTag("UFOManager");
        }
        if (UFOManager.name != "UfoManager")
        {
            UFOManager = GameObject.Find("UfoManager");
        }
        if (!HappyEnding)
        {
            if (transform.Find("HappyEnding").gameObject.activeInHierarchy == true)
            {
                transform.Find("HappyEnding").gameObject.SetActive(false);
            }
            HappyEnding = transform.Find("HappyEnding").gameObject;
        }
        if (!BadEnding)
        {
            if (transform.Find("BadEnding").gameObject.activeInHierarchy == true)
            {
                transform.Find("BadEnding").gameObject.SetActive(false);
            }
            BadEnding = transform.Find("BadEnding").gameObject;

        }
        StartCoroutine(EndingMgrCoroutine());

    }
    void ManagingEndings()
    {
        if (CurrentEndingState != EndingState.GamePlaying)
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
            switch (CurrentEndingState)
            {
                case EndingState.HappyEnding:

                    if (HappyEnding.activeInHierarchy == false)
                    {
                        HappyEnding.SetActive(true);
                    }
                    if (PauseButton.activeInHierarchy == true)
                    {
                        PauseButton.SetActive(false);
                    }
                    if (PauseCanvas.activeInHierarchy == false)
                    {
                        PauseCanvas.SetActive(true);
                       //게임 끝나면 다시 돌아가는 것 필요
                    }
                    break;
                case EndingState.BadEnding:
                    break;

            }
        }
    }
         
    // Update is called once per frame
    void Update()
    {
        if (CurrentEndingState!=EndingState.GameNotStart)
        {
            StateTrueFalse = true;
        }
        else
        {
            if (CurrentEndingState == EndingState.GameNotStart)
            {
                if (this.gameObject.GetComponent<QuizCSVParser>().ChooseQuiz != QuizCSVParser.QuizType.NotYet)
                {
                    if (CurrentEndingState != EndingState.GamePlaying)
                    {
                        CurrentEndingState = EndingState.GamePlaying;
                    }
                }
                else
                {
                    StateTrueFalse = false;
                    if (Time.timeScale != 0)
                    {
                        Time.timeScale = 0;
                    }
                }
            }
        }
        // ManagingEndings();
    }
}
