using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    public string UfoAnswer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //이펙트 불러오는 스크립트 필요
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<QuizCSVParser>().KillingUfoCount++;
            Destroy(this.gameObject);
        }
    }
}
