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
    public enum EndingState { GameNotFinished,HappyEnding,BadEnding};
    public EndingState CurrentEndingState = EndingState.GameNotFinished;
    // Start is called before the first frame update
    //코루틴으로 바꾸는 게 낫나???
    IEnumerator EndingMgrCoroutine()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (CurrentEndingState != EndingState.GameNotFinished)
            {
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
                    }
                        break;
                    case EndingState.BadEnding:
                        break;

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

    }
    void ManagingEndings()
    {
        if (CurrentEndingState != EndingState.GameNotFinished)
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
        ManagingEndings();
    }
}
