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
        int min = (int)Stats.gameTime / 60;
        int sec = (int)Stats.gameTime % 60;
        int ms = (int)(Stats.gameTime * 100) % 100;
        string timerText = min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("00");
        statsText.text = Stats.playerName + "\n" + Stats.score + "\n" + timerText;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("HomeMenu");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}