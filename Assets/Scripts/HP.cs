using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int HitPoint = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(/*퀴즈가틀렸을 경우*/Input.GetButtonDown("Fire1"))
        {
            HitPoint--;
            print(HitPoint);
        }
    }
}
