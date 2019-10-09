﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float BulletLifeTime = 2f;
    public bool CanMove = true;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, BulletLifeTime);
        print("BALL APPEAR");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove == true)
        {
            Move();

        }
    }
    void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * BulletLifeTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ufo")
        {
            print("Bullet Meets UFO");
            GameObject.Find("ScoreCanvas").GetComponent<Score>().ScoreT += 5;
            Destroy(this.gameObject);
        }
    }
}

