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

    AudioSource audioSource;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        rb = GetComponent<Rigidbody2D>();
        hasStarted = false;
        audioSource = GetComponent<AudioSource>();
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
    s
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            audioSource.pitch = 2f;
        }
        else
        {
            audioSource.pitch = 1f;
        }

        audioSource.Play();
    }
}
