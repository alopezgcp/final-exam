using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

public class PlayerScoreMgr : MonoBehaviour
{
    public InputField NameField;
    public Text playerScoresText;
    public Text highScoresText;

    private List<string> playerScores;
    private List<string> allScores;

    private void Start()
    {
        FileManager fm = new FileManager();
        allScores = fm.GetScores();
        playerScores = new List<string>();

        PrintTopScores();
    }

    private void Update()
    {
        if(NameField.text != Stats.playerName)
        {
            SetPlayerName();
        }
    }

    public void SetPlayerName()
    {
        NameField.characterLimit = 25;
        Stats.playerName = NameField.text;

        if (NameField.text == "")
        {
            playerScoresText.text = "Please provide a name.";
        }
        else {
            GetPlayerScores();
            if(playerScores.Count == 0)
            {
                playerScoresText.text = "No scores found for " + Stats.playerName;
            }
            else
            {
                PrintPrevPlayerScores();
            }
        }
    }

    void GetPlayerScores()
    {
        playerScores = new List<string>();
        string[] data = new string[2];
        foreach (string score in allScores)
        {
            data = score.Split(',');
            if(data[1] == Stats.playerName)
            {
                playerScores.Add(score);
            }
        }
    }

    void PrintPrevPlayerScores()
    {
        int lastScoreIndex = playerScores.Count - 1;
        int numScores = 0;
        string scoreString = "";

        while(lastScoreIndex >= 0 && numScores <= 3)
        {
            ++numScores;

            scoreString += "\n" + numScores.ToString() + ". " + 
                playerScores[lastScoreIndex].Split(',')[0];

            --lastScoreIndex;
        }

        playerScoresText.text = "Name: " + Stats.playerName + "\n" + scoreString;
    }

    void PrintTopScores()
    {
        string entryA, entryB;
        int scoreA, scoreB;

        //insertion sort
        for (int i = 0; i < allScores.Count - 1; ++i)
        {
            for (int j = i; j >= 0; --j)
            {
                entryA = allScores[j];
                scoreA = int.Parse(entryA.Split(',')[0]);

                entryB = allScores[j + 1];
                scoreB = int.Parse(entryB.Split(',')[0]);

                if (scoreA < scoreB)
                {
                    allScores[j] = entryB;
                    allScores[j + 1] = entryA;
                }
            }
        }

        string highScoresString = "";
        for (int i = 0; i < 3; ++i)
        {
            string name = allScores[i].Split(',')[1];
            string score = allScores[i].Split(',')[0];
            highScoresString += (i+1) + ". " + name + " - " + score + "\n";
        }
        highScoresText.text = highScoresString;
    }

    public void StartGame()
    {
        if (Stats.playerName != "")
        {
            SceneManager.LoadScene("3Game");
        }
        else
            playerScoresText.text = "You must provide a name to begin playing.";
    }
}
