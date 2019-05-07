using UnityEngine;
using UnityEngine.UI;

public class LivesTracker : MonoBehaviour
{
    public void DecreaseLives()
    {
        Stats.lives -= 1;
    }
    public void IncreaseLives()
    {
        Stats.lives += 1;
    }

}
