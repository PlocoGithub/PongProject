using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public string upKey = "w";
    public string downKey = "s";

    void Update()
    {
        float move = Input.GetAxisRaw(upKey + downKey) * speed * Time.deltaTime;
        transform.Translate(0, move, 0);

        // Clamp paddle position within screen boundaries
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f); // Adjust boundaries as needed
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}