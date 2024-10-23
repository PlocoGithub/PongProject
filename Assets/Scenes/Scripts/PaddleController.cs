using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;       
    public bool isPlayer1;           

    private void Update()
    {
        if (isPlayer1)
        {
            MovePaddle(KeyCode.W, KeyCode.S);  
        }
        else
        {
            MovePaddle(KeyCode.UpArrow, KeyCode.DownArrow);
        }
    }
    private void MovePaddle(KeyCode upKey, KeyCode downKey)
    {
        float move = 0f;

        if (Input.GetKey(upKey))
        {
            move = speed * Time.deltaTime;
        }
        else if (Input.GetKey(downKey))
        {
            move = -speed * Time.deltaTime;
        }

        transform.Translate(0, move, 0);
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);
        transform.position = pos;
    }
}