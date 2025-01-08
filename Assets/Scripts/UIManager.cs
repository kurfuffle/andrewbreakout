using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject gameOverScreen;
    public RectTransform hearts;
    private TMP_Text score;
    private void Awake()
    {
        base.Awake();
        score = transform.GetComponentInChildren<TMP_Text>();
        gameOverScreen.SetActive(false);

        
    }
    
    public void ScoreUpdate(int setScore)
    {
        score.text = "Score: " + setScore;
    }

    void Update()
    {
        hearts.sizeDelta = new Vector2(GameManager.instance.hp * 30, 30);
    }

    public void ShowGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void PlayAgain(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Quit(){
        Application.Quit();
    }

}
