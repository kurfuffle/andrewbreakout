using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    void Update()
    {
        if(Time.timeScale == 1){
            float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            transform.position = new Vector2(Mathf.Clamp(mouseX, -7.8f, 7.8f), transform.position.y);
        }
    }
}








//Powerups