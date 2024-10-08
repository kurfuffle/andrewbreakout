using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]Level[] levels;
    [SerializeField]int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
class Level{
    public BrickData[,] bricks = new BrickData[7,7];
}
[System.Serializable]
class BrickData{
    public int health = 1;
}