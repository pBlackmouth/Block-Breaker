using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    Paddle paddle1;

    Vector2 paddleToBallVector;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y) + paddleToBallVector;
    }
}
