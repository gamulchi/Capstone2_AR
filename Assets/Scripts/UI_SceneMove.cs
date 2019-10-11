using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UI_SceneMove : MonoBehaviour
{

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
        
    }
    public void Game_Start()
    {
        SceneManager.LoadScene("02.PlayScene");
        //if (PlayScene.name!="")
        //{
        //    SceneManager.LoadScene(PlayScene.name);

        //}
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
