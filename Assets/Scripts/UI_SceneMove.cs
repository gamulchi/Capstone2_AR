using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UI_SceneMove : MonoBehaviour
{
    public bool IsEnglishQuiz = true;
    public GameObject StartButton;
    public GameObject TutorialButton;
    public GameObject ExitButton;
    public GameObject EnglishButton;
    public GameObject MathButton;
    public GameObject BackButton;
    public GameObject PauseUI;
    // Start is called before the first frame update
    void Start()
    {
        if (PauseUI)
        {
            PauseUI.SetActive(false);
        }

    }


    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name== "02.PlayScene"&&this.gameObject.name== "UI_MainScene")
        {
            if (GameObject.FindGameObjectWithTag("Canvas").GetComponent<EndingManager>().CurrentEndingState != EndingManager.EndingState.GameNotStart)
            {
                GameObject.FindGameObjectWithTag("Canvas").GetComponent<EndingManager>().CurrentEndingState = EndingManager.EndingState.GameNotStart;
            }
            if (IsEnglishQuiz == true)
            {
                GameObject.FindGameObjectWithTag("Canvas").GetComponent<QuizCSVParser>().ChooseQuiz = QuizCSVParser.QuizType.English;
            }
            if (IsEnglishQuiz == false)
            {
                GameObject.FindGameObjectWithTag("Canvas").GetComponent<QuizCSVParser>().ChooseQuiz = QuizCSVParser.QuizType.Math;
            }
            Destroy(this.gameObject);
        }
    }
    public void Game_Start()
    {
        StartButton.SetActive(false);
        TutorialButton.SetActive(false);
        ExitButton.SetActive(false);
        EnglishButton.SetActive(true);
        MathButton.SetActive(true);
        BackButton.SetActive(true);
    }
    public void Game_Start_Eng()
    {
       IsEnglishQuiz = true;
        SceneManager.LoadScene("02.PlayScene");
        DontDestroyOnLoad(this.gameObject);
    }
    public void Game_Start_Math()
    {
        IsEnglishQuiz = false;
        SceneManager.LoadScene("02.PlayScene");
        DontDestroyOnLoad(this.gameObject);
    }
    public void Game_Tutorial()
    {
        SceneManager.LoadScene("03.TutorialScene");
    }
    public void Game_Pause()
    {
        PauseUI.SetActive(true);
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }
    public void Game_Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Game_Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("02.PlayScene");
    }
    public void Game_BacktoMain()
    {
        EnglishButton.SetActive(false);
        MathButton.SetActive(false);
        BackButton.SetActive(false);
        StartButton.SetActive(true);
        ExitButton.SetActive(true);
        TutorialButton.SetActive(true);
    }
    public void Game_Menu()
    {
        SceneManager.LoadScene("01.MainScene");
        Time.timeScale = 1f;
    }
    public void Game_Exit()
    {
        Application.Quit();
    }
}
