using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//임시class
namespace ex
{
    public class create : MonoBehaviour
    {
        public static int count = 0;
        // Start is called before the first frame update
        public void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "ufo")
            {
                Destroy(GameObject.FindGameObjectWithTag("ufo"), 0f); //충돌시 ufo 파괴
                count++; //퀴즈 조건 변수
            }
        }


    }
}