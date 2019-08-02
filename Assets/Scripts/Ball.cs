using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] float randomFactor = 0.2f;

    public bool hasStarted = false;
    Vector2 paddleToBallVector;

    Rigidbody2D rb;
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

        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));
        if (collision.gameObject.CompareTag("Paddle"))
        {
            audioSource.pitch = 2f;
        }
        else
        {
            audioSource.pitch = 1f;
        }

        audioSource.Play();
        rb.velocity += velocityTweak;
    }
}
