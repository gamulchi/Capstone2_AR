using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public GameObject HP;
    public GameObject[] HPImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<HP>().HitPoint < 1)
        {
            HPImage[0].SetActive(false);
        }
        if (GetComponent<HP>().HitPoint < 2)
        {
            HPImage[1].SetActive(false);
        }
        if (GetComponent<HP>().HitPoint < 3)
        {
            HPImage[2].SetActive(false);
        }
        if (GetComponent<HP>().HitPoint < 4)
        {
            HPImage[3].SetActive(false);
        }
        if (GetComponent<HP>().HitPoint < 5)
        {
            HPImage[4].SetActive(false);
        }
    }
}
