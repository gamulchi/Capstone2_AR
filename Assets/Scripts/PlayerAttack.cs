using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Bullet;
    public Text CText;
    public int i;
    public float ShootingTermTime = 3;
    public float ShootingTime = 0;
    public bool TimeCheckStart = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!CText)
        {
            CText = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Text").gameObject.GetComponent<Text>();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeCheckStart == true)
        {
            if (ShootingTime < ShootingTermTime)
            {
                ShootingTime += Time.deltaTime;
            }
            if (ShootingTime >= ShootingTermTime)
            {
                ShootingTime = 0;
                TimeCheckStart = false;
            }

        }
        
       
        if (Input.touchCount==1)

        {
            Touch touch = Input.GetTouch(0);

            
            switch (touch.phase) {
                //이 switch 문 이 있어야 한번 터치할때 Bullet 여러개 instantiate 안됨
                case TouchPhase.Ended:
                    if (TimeCheckStart == false)
                    {
                        if (Bullet)
                        {
                            Instantiate(Bullet, transform.parent);
                        }
                        TimeCheckStart = true;
                    }
                   
                    break;
            }
            
            CText.text = "SCREEn TOUCH:"+Input.touchCount;
            
        }
        
    }
}
