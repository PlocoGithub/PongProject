using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 ballSize = new Vector2(0.5f, 0.5f);
    public LayerMask paddleLayer;

    private Vector2 direction;
    private float leftBoundary;
    private float rightBoundary;

    void Start()
    {
        leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        StartBallMovement();
    }

    void StartBallMovement()
    {
        float randomX = Random.Range(0, 2) == 0 ? -1f : 1f;
        float randomY = Random.Range(-1f, 1f);
        direction = new Vector2(randomX, randomY).normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        CheckPaddleCollision();
        if (transform.position.y > 4.5f || transform.position.y < -4.5f)
        {
            direction.y = -direction.y;
        }
        CheckScore();
    }

    void CheckPaddleCollision()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, ballSize, 0f, paddleLayer);

        if (hit != null && hit.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
            float paddleY = hit.transform.position.y;
            float ballY = transform.position.y;
            float offset = ballY - paddleY;
            direction.y = offset * 2;
            direction = direction.normalized;
        }
    }

    void CheckScore()
    {
        if (transform.position.x < leftBoundary)
        {
            Debug.Log("Player 2 scores a point!");
            ResetBall();
        }
        else if (transform.position.x > rightBoundary)
        {
            Debug.Log("Player 1 scores a point!");
            ResetBall();
        }
    }
    void ResetBall()
    {
        transform.position = Vector3.zero;

        StartBallMovement();
    }
}