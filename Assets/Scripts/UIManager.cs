using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image hearts;
    private Text score;
    private void Awake()
    {
        score = transform.GetComponentInChildren<Text>();
    }
    
    public void scoreUpdate(int setScore)
    {
        score.text = "Score: " + setScore;
    }

    void Update()
    {
        
    }
}
