using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float screenWidthInUnits = 16f;
    [SerializeField]
    private float minPosXInUnits = 0;
    [SerializeField]
    private float maxPosXInUnits = 16;
    // Start is called before the first frame update

    GameSession gameSession;
    Ball ball;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(GetXPos(), transform.position.y);
    }

    float GetXPos()
    {
        float xValue = 0;
        if (gameSession.IsAutoPlayEnabled() && ball.hasStarted)
        {
            xValue = ball.transform.position.x;
        }
        else
        {
            xValue = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minPosXInUnits, maxPosXInUnits);
        }

        return xValue;
    }
}
