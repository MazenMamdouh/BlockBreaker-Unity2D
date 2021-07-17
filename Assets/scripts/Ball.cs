using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] PaddleScript paddle1;
    bool hasStarted = false;
    Vector3 PaddleToBallVector;
    void Start()
    {
        PaddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBall();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector3(3f,15f,0.5f);
        }
    }

    void LockBall()
    {
        Vector3 paddlepos = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, 0.5f);
        transform.position = paddlepos + PaddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
