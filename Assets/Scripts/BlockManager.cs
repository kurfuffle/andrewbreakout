using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private GameObject ball;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        ball = GameObject.Find("Ball");
    }


    void Update()
    {
        sr.color = hpColors[hp - 1];
        if(Physics2D.IsTouching(GetComponent<Collider2D>(), ball.GetComponent<Collider2D>()))
        {
            hp--;
            if(hp <= 0) Destroy(gameObject);
        }
    }
}
