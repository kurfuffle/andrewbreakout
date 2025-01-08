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
        
        Time.timeScale = 1;
        
    }

    
    void Update()
    {
        if(hp <= 0)
        {
            UIManager.instance.ShowGameOverScreen();
        }
    }

    public void ChangeScore(int amount){
        score += amount;
        UIManager.instance.ScoreUpdate(score);
    }

}
