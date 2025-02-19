using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1;
    GameObject paddle;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.Find("Paddle");
    }

    void Update()
    {
        if(transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0 ,0)).x - transform.lossyScale.x / 2)
        {
            rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), rb.velocity.y);
        }
        if(transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(0, 0 ,0)).x + transform.lossyScale.x / 2)
        {
            rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), rb.velocity.y);
        }
        if(transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - transform.lossyScale.y / 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, -Mathf.Abs(rb.velocity.y));
        }
        if (rb.velocity == Vector2.zero) 
        {
            transform.position = paddle.transform.position + new Vector3(0, 0.6f, 0);
            if(Input.GetMouseButtonDown(0)  || Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * speed;
            }
        }
        if(Physics2D.IsTouching(GetComponent<Collider2D>(), paddle.GetComponent<Collider2D>()))
        {

            rb.velocity = new Vector2((transform.position.x - paddle.transform.position.x) * 2, 1).normalized * rb.velocity.magnitude;
        }
        
        if(transform.position.y < -5.25f)
        {
            rb.velocity = Vector2.zero;
            GameManager.instance.hp--;
        }

    }
}
