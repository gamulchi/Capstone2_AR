using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UI_Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Game_Start()
    {
        SceneManager.LoadScene("Main");
    }
    public void Game_Exit()
    {
        Application.Quit();
    }
}
