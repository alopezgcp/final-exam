using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EndManager : MonoBehaviour
{
    public Text statsText;

    private void Start()
    {
        DisplayStats();
    }

    public void DisplayStats()
    {
        string statString = "Name\n  " + Stats.playerName;
        statString += "\nScore\n  " + Stats.score;
        statString += "\nSpeed\n  " + Stats.speed;
        statString += "\nSize\n  " + Stats.size;
        statString += "\nLives Left\n  " + Stats.lives;

        float playTime;
        if (!(Stats.gameIsLimitted))
            playTime = Stats.gameTime;
        else
            playTime = Stats.startTime - Stats.gameTime;

        int min = (int)playTime / 60;
        int sec = (int)playTime % 60;
        int ms = (int)(playTime * 100) % 100;
        string timerText = min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("00");
        statString += "\nPlay Time\n  " + timerText;

        statsText.text = statString;
    }
}