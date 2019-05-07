using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setup : MonoBehaviour
{
    public Slider sizeSlider;
    public Slider speedSlider;

    public Toggle slideLock;
    public Dropdown gameTime;

    private void Update()
    {
    }

    public void NextScene()
    {
        Stats.size = sizeSlider.value;
        Stats.speed = speedSlider.value;

        if (gameTime.value == 0)
            Stats.gameIsLimitted = false;
        else
            Stats.gameIsLimitted = true;

        SceneManager.LoadScene("2HighScores");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ToggleSliders()
    {
        // fruit size
        if (sizeSlider.interactable) sizeSlider.interactable = false;
        else sizeSlider.interactable = true;
        // spawn rate
        if (speedSlider.interactable) speedSlider.interactable = false;
        else speedSlider.interactable = true;
    }

    public void SetGameTime()
    {
        if (gameTime.value == 0) Stats.startTime = 0f;
        else if (gameTime.value == 1) Stats.startTime = 60f;
        else if (gameTime.value == 2) Stats.startTime= 120f;
    }
}
