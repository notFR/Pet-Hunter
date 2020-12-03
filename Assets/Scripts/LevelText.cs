using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public Text CurrentLevelText, NextLevelText;
    public int nextLevel;
    void Start()
    {
        SetLevelText();
    }

    
    void Update()
    {
        
    }
    public void SetLevelText()
    {
        CurrentLevelText.text = PlayerPrefs.GetInt("CurrentLevel",0).ToString();
        nextLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        nextLevel += 1;
        NextLevelText.text = nextLevel.ToString();
    }
}
