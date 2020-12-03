using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score;
    public Text scoreText;
    [SerializeField]
    private GameObject PausePanel;
    public GameObject offbutton, onbutton;


    public Image x5000Image;
    private bool display5000;
    private float display5000Timer;
    private void Start()
    {
        Score = 0;
        scoreText.text =  Score.ToString();
        PausePanel.SetActive(false);
        display5000 = false;
    }

    public void PauseGame(bool pause) 
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);

    }
    public void UnPauseGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        
    }
    public void offSound()
    {
        PlayerPrefs.SetInt("_İsSoundStop", 1);
        offbutton.SetActive(false);
        onbutton.SetActive(true);
    }
    public void onSound()
    {
        PlayerPrefs.SetInt("_İsSoundStop", 0);
        onbutton.SetActive(false);
        offbutton.SetActive(true);
    }
    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);

        Time.timeScale = 1f;
    }

    public void Update()
    {
        if(Score >= 5000)
        {
            if (!display5000)
            {
                display5000 = true;
                display5000Timer = 0.0f;
            }
        }
        if(display5000)
        {
            display5000Timer += Time.deltaTime;

            x5000Image.enabled = true;
            //Hide after 3 seconds
            if (display5000Timer > 1.0f)
            {
                x5000Image.enabled = false;
            }

        }
    }
}
