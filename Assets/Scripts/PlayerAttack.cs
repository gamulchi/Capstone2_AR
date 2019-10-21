using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Bullet;
    public int i;
    public float ShootingTermTime = 3;
    public float ShootingTime = 0;
    public bool TimeCheckStart = false;
    // Start is called before the first frame update
    IEnumerator BulletTime()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (TimeCheckStart == true)
            {
                print("Attack Term Time");
                yield return new WaitForSeconds(ShootingTermTime);
                TimeCheckStart = false;
            }
        }
    }

    void Start()
    {
        StartCoroutine(BulletTime());
    }

    // Update is called once per frame
    void Update()
    {
        //if (TimeCheckStart == true)
        //{
        //    print("TimeCheck");
        //    if (ShootingTime < ShootingTermTime)
        //    {
        //        ShootingTime += Time.deltaTime;
        //    }
        //    if (ShootingTime >= ShootingTermTime)
        //    {
        //        ShootingTime = 0;
        //        TimeCheckStart = false;
        //    }

        //}
        if (Input.touchCount==1)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                //이 switch 문 이 있어야 한번 터치할때 Bullet 여러개 instantiate 안됨
                case TouchPhase.Ended:
                    print("TOUCH");

                    if (TimeCheckStart == false)
                    {
                        if (Bullet && GameObject.FindGameObjectWithTag("Canvas").GetComponent<QuizCSVParser>().CurrentPlayState == QuizCSVParser.PlayState.NoQuiz)
                        {        //총알 존재&&현재 퀴즈 상태가 없으면 공격 가능

                            Attack();
                        }
                        TimeCheckStart = true;
                    }
                    break;
            }
        }
        
        
    }
    public void Attack()
    {
        Instantiate(Bullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
