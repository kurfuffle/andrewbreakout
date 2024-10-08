using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Brick : MonoBehaviour
{
    public static Color[] hpColors = new Color[]{
        Color.black,
        Color.blue,
        Color.magenta,
        Color.cyan,
        Color.green,
        Color.yellow,
        Color.red
    };
    [SerializeField] int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
