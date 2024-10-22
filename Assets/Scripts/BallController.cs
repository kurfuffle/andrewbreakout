using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Mathf.Abs(transform.position.x) >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0 ,0)).x - transform.lossyScale.x / 2)
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }
}
