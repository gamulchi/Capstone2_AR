using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : MonoBehaviour
{
    public float Speed = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        if((transform.position.y)%1>0|| (transform.position.z) % 1 > 0)
        {
            print("소수소수");

            //0으로 나누었을 때 나머지가 0 초과=>소수
            int y = (int)gameObject.transform.position.y;
            int z = (int)gameObject.transform.position.z;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, y, z);
        }
    }
    void Move()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            print("Ufo Meets Ground "+  this.gameObject.name);
            if (GameObject.FindGameObjectWithTag("Canvas").transform.Find("Life").gameObject.GetComponent<LifeManager>().CurrentLifeCount > 0)
            {
                GameObject.FindGameObjectWithTag("Canvas").transform.Find("Life").gameObject.GetComponent<LifeManager>().CurrentLifeCount--;
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<QuizCSVParser>().KillingUfoCount++;
            Destroy(this.gameObject);
        }
    }
   

}
