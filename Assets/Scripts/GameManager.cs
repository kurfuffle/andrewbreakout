using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    public int hp;
    int score;
    UIManager ui;
    void Start()
    {
        
        
    }

    
    void Update()
    {
        if(hp <= 0)
        {
            UIManager.instance.ShowGameOverScreen();
        }
    }
}
