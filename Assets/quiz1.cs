using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using ex; //전역변수 사용할 namespace

public class quiz1 : MonoBehaviour
{
    public GameObject quizz;
    public GameObject topquiz1;
    private float time;
    // Start is called before the first frame update

    void Update()
    {
        
        //if(count == 5)  전역변수 count 퀴즈 호출 조건
    //   {
            quizz.SetActive(true);
    //   }
       
        time += Time.deltaTime;
        if (time == 4)
        {
            quizz.SetActive(false);
            topquiz1.SetActive(true);
        }
    }
}
