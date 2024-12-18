using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject gameOverScreen;
    public RectTransform hearts;
    private Text score;
    private void Awake()
    {
        base.Awake();
        score = transform.GetComponentInChildren<Text>();
        gameOverScreen.SetActive(false);

        
    }
    
    public void scoreUpdate(int setScore)
    {
        score.text = "Score: " + setScore;
    }

    void Update()
    {
        hearts.sizeDelta = new Vector2(GameManager.instance.hp * 30, 30);
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

}
