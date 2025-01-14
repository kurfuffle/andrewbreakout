using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public List<string> powerUpList = new List<string>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(string powerUp in powerUpList)
        {
            Invoke(powerUp);
        }
    }

   
    void SpeedUp()
    {
        GameObject.Find("Ball").GetComponent<Rigidbody2D>().velocity *= 2;

    }

}
