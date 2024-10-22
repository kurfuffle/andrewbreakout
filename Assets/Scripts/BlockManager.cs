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

    public int health = 1;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        sr.color = hpColors[health - 1];
    }
}
