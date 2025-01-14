using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public class BlockManager : MonoBehaviour
{
    public static Color[] hpColors = new Color[]{
        Color.white,
        Color.black,
        Color.blue,
        Color.magenta,
        Color.cyan,
        Color.green,
        Color.yellow,
        Color.red
    };

    public int hp = 1;
    SpriteRenderer sr;
    private Collider2D ball;
    Rigidbody2D orb;
    private bool debounce = true;
    BoxCollider2D top;
    BoxCollider2D bottom;
    BoxCollider2D left;
    BoxCollider2D right;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        ball = GameObject.Find("Ball").GetComponent<Collider2D>();
        orb = ball.GetComponent<Rigidbody2D>();

        top = gameObject.AddComponent<BoxCollider2D>();
        top.size = new Vector2(1, .1f);
        top.offset = new Vector2(0, 0.45f);
        top.isTrigger = true;

        bottom = gameObject.AddComponent<BoxCollider2D>();
        bottom.size = new Vector2(1, .1f);
        bottom.offset = new Vector2(0, -0.45f);
        bottom.isTrigger = true;

        left = gameObject.AddComponent<BoxCollider2D>();
        left.size = new Vector2(.1f, 1);
        left.offset = new Vector2(-.45f, 0);
        left.isTrigger = true;

        right = gameObject.AddComponent<BoxCollider2D>();
        right.size = new Vector2(.1f, 1);
        right.offset = new Vector2(.45f, 0);
        right.isTrigger = true;
    }


    void FixedUpdate()
    {
        sr.color = hpColors[hp - 1];

        if (!debounce) return;

        if(Physics2D.IsTouching(top,ball))
        {
            orb.velocity = new Vector2(orb.velocity.x, Mathf.Abs(orb.velocity.y));
            Break();
        }
        else if(Physics2D.IsTouching(bottom,ball))
        {
            orb.velocity = new Vector2(orb.velocity.x, -Mathf.Abs(orb.velocity.y));
            Break();
        }
        else if(Physics2D.IsTouching(left,ball))
        {
            orb.velocity = new Vector2(-Mathf.Abs(orb.velocity.x), orb.velocity.y);
            Break();
        }
        else if(Physics2D.IsTouching(right,ball))
        {
            orb.velocity = new Vector2(Mathf.Abs(orb.velocity.x), orb.velocity.y);
            Break();
        }
    }

    void Break()
    {
        hp--;
        if(hp <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.ChangeScore(1);
        }
        debounce = false;
        Invoke("Debounce", .1f);
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {

    //     if(other.gameObject == ball && debounce)
    //     {
    //         hp--;
    //         if(hp <= 0) Destroy(gameObject);
    //         Debug.Log(other.transform.position.y - transform.position.y);
    //          Rigidbody2D orb = other.GetComponent<Rigidbody2D>();
    //         float offsetY = other.transform.position.y - transform.position.y;
    //         if(MathF.Abs(offsetY) >= 0.45f)
    //         {
    //             orb.velocity = new Vector2(orb.velocity.x, -orb.velocity.y);
    //         } 
    //         else
    //         {
    //             orb.velocity = new Vector2(-orb.velocity.x, orb.velocity.y);
    //         }
    //         debounce = false;
    //         Invoke("Debounce", .1f);
    //     }
    // }
    void Debounce()
    {
        debounce = true;
    }

}
