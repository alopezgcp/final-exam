using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HighScoreMgr : MonoBehaviour
{
    public Text nameText, scoreText;
    private List<string> allScores = new List<string>();

    private void Start()
    {
        DisplayScores();
    }

    public void DisplayScores()
    {
        FileManager fm = new FileManager();
        allScores = fm.GetScores();

        SortScores();

        string nameString = "", scoreString = "";

        for (int i = 0; i < 10; ++i)
        {
            nameString += (i + 1).ToString() + ". " + allScores[i].Split(',')[1] + "\n";
            scoreString += allScores[i].Split(',')[0] + "\n";
        }
        
        nameText.text = nameString;
        scoreText.text = scoreString;
    }

    void SortScores()
    {
        string entryA, entryB;
        int scoreA, scoreB;

        //insertion sort
        for(int i = 0; i < allScores.Count - 1; ++i)
        {
            for(int j = i; j >= 0; --j)
            {
                entryA = allScores[j];
                scoreA = int.Parse(entryA.Split(',')[0]);

                entryB = allScores[j + 1];
                scoreB = int.Parse(entryB.Split(',')[0]);

                if(scoreA < scoreB)
                {
                    allScores[j] = entryB;
                    allScores[j + 1] = entryA;
                }
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("EndMenu");
    }
}