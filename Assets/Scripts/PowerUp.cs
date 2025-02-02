using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Kind {
        None,
        SpeedUp,
        IncreasePaddleSize,
        IncreaseBallSize
    }

    public List<Kind> powerUpList = new();

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
            }
        }
        transform.position = new Vector2(50,50);
        Destroy(gameObject, 30);
    }

    IEnumerator SpeedUp()
    {
        GameObject.Find("Ball").GetComponent<Rigidbody2D>().velocity *= 2;
        yield return new WaitForSeconds(10);
        GameObject.Find("Ball").GetComponent<Rigidbody2D>().velocity /= 2;
    }

    IEnumerator IncreasePaddleSize()
    {
        GameObject paddle = GameObject.Find("Paddle");
        Vector3 originalScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(originalScale.x * 2, originalScale.y, originalScale.z);
        yield return new WaitForSeconds(10);
        paddle.transform.localScale = originalScale;
    }

    IEnumerator IncreaseBallSize()
    {
        GameObject ball = GameObject.Find("Ball");
        Vector3 originalScale = ball.transform.localScale;
        ball.transform.localScale = new Vector3(originalScale.x * 2, originalScale.y * 2, originalScale.z);
        yield return new WaitForSeconds(10);
        ball.transform.localScale = originalScale;
    }
}