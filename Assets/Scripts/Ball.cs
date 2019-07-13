using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{

    [SerializeField]
    Paddle paddle1;

    [SerializeField]
    float xPush = 2f;

    [SerializeField]
    float yPush = 10f;

    Rigidbody2D rb;
    bool hasStarted = false;

    Vector2 paddleToBallVector;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        rb = GetComponent<Rigidbody2D>();
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y) + paddleToBallVector;
    }
}
