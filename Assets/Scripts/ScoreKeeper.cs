using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreKeeper : MonoBehaviour
{
    public void IncreaseScore() // clicking on + button increases score
    {
        Stats.score += 1;
    }

    public void DecreaseScore() // clicking on - button decreases score
    {
        Stats.score -= 1;
    }
 
}
