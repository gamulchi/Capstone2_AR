using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPlay : MonoBehaviour
{
    public GameObject[] Intro_image;
    int num=0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Intro_Play", 0, 1f);
        Invoke("Cancel",5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                SceneManager.LoadScene("01.MainScene");
            }
        }
    }
    void Intro_Play()
    {
        if (num<4)
        {
            Intro_image[num].SetActive(true);
            num++;
        }
    }
    void Cancel()
    {
        CancelInvoke("Intro_Play");
        SceneManager.LoadScene("01.MainScene");
    }
}
