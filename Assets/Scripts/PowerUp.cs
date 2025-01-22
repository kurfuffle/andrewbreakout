using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Kind {
        None,
        SpeedUp
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

}
