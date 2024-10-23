using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;

    void Start()
    {
        // Initialize the ball's direction
        direction = new Vector2(1, 1).normalized; // Adjust direction as needed
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Check for boundary collisions
        if (transform.position.y > 5 || transform.position.y < -5)
        {
            direction.y = -direction.y; // Reverse direction on Y axis
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            direction.x = -direction.x; // Reverse direction on X axis
        }
    }
}
