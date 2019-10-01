using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : MonoBehaviour
{
    public float Speed = 3;
    // Start is called before the first frame update
    void Start()
    {
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
}
