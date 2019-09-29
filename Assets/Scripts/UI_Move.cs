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
        print("pp");
        //빌드한 모든 씬 숫자들
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Game_Start()
    {
        SceneManager.LoadScene(1);
        //if (PlayScene.name!="")
        //{
        //    SceneManager.LoadScene(PlayScene.name);

        //}
    }
    public void Game_Exit()
    {
        Application.Quit();
    }
}
