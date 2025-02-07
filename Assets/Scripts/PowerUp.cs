using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public enum Kind {
        None,
        SpeedUp,
        IncreasePaddleSize,
        IncreaseBallSize,
        SlowDown
    }

    public List<Kind> powerUpList = new();

    float ballSize = 0.5f;

    void Awake(){
        for(int i = 0; i < Random.Range(1, 4); i++){
            powerUpList.Add((Kind) System.Enum.Parse(typeof(Kind), Random.Range(1, 5).ToString()));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player")) return;
        foreach(Kind powerUp in powerUpList)
        {
            switch(powerUp)
            {
                case Kind.SpeedUp:
                    StartCoroutine(SpeedUp());
                    break;
                case Kind.IncreasePaddleSize:
                    StartCoroutine(IncreasePaddleSize());
                    break;
                case Kind.IncreaseBallSize:
                    StartCoroutine(IncreaseBallSize());
                    break;
                case Kind.SlowDown:
                    StartCoroutine(SlowDown());
                    break;
            }
        }
        transform.position = new Vector2(50,50);
        Destroy(gameObject, 30);
    }

    IEnumerator SpeedUp()
    {
        Rigidbody2D ball = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        Vector2 vel = ball.velocity;
        ball.velocity *= 2;
        yield return new WaitForSeconds(10);
        ball.velocity = vel;
    }

    IEnumerator IncreasePaddleSize()
    {
        SpriteRenderer sr = GameObject.Find("Paddle").GetComponent<SpriteRenderer>();
        Vector2 ogSize = sr.size;
        sr.size = new Vector2(ogSize.x * 2, ogSize.y);
        yield return new WaitForSeconds(10);
        sr.size = ogSize;
    }

    IEnumerator IncreaseBallSize()
    {
        ballSize += 0.5f;
        GameObject ball = GameObject.Find("Ball");
        ball.transform.localScale = new Vector2(ballSize, ballSize);
        yield return new WaitForSeconds(10);
        ballSize -= 0.5f;
        ball.transform.localScale = new Vector2(ballSize, ballSize);
    }

    IEnumerator SlowDown()
    {
        Rigidbody2D ball = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        Vector2 vel = ball.velocity;
        float elapsedTime = 0;
        while(elapsedTime < 10)
        {
            if(Mathf.Sign(ball.velocity.x) != Mathf.Sign(vel.x)) vel.x *= -1;
            if(Mathf.Sign(ball.velocity.y) != Mathf.Sign(vel.y)) vel.y *= -1;
            if(ball.velocity.x == 0 && ball.velocity.y == 0) break;
            if(ball.transform.position.y <= -2) ball.velocity = vel / 2;
            else ball.velocity = vel;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }


}