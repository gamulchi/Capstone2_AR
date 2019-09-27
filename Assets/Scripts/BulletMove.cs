using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float BulletLifeTime=2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, BulletLifeTime);
        print("BALL APPEAR");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * BulletLifeTime);
    }
}
