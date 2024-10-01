using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    void Update()
    {
        float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector2(Mathf.Clamp(mouseX, -7.8f, 7.8f), transform.position.y);
    }
}
