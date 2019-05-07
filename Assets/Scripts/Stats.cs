using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour {

    public static string playerName = "";

    // assume player selected unlimitted game time
    public static float startTime = 0f;
    public static float gameTime = 0f;
    public static bool gameIsLimitted = false;

    public static float speed = 1f;
    public static float size = 1f;
    public static int score = 0;
    public static int lives = 9;

    private int min = 0;
    private int sec = 0;
    private int ms = 0;

    public Text speedText;
    public Text sizeText;
    public Text scoreText;
    public Text livesText;
    public Text timerText;

	void Start ()
    {
        score = 0;
        lives = 9;
        speedText.text = speed.ToString();
        sizeText.text = size.ToString();
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        gameTime = startTime;
	}
    
    private void Update()
    {
        // update score and lives
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();

        // update game clock
        if (gameIsLimitted)
        {
            gameTime -= Time.deltaTime;
        }
        else gameTime += Time.deltaTime;

        min = (int)gameTime / 60;
        sec = (int)gameTime % 60;
        ms = (int)(gameTime * 100) % 100;

        // only update timer text field when time > 0
        // (otherwise, timer will go negative for a couple of ms)
        if(gameTime >= 0)
            timerText.text = min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("00");

        // check if level needs to end
        if (gameTime < 0f || lives == 0) EndGame();
    }

    public void EndGame()
    {
        ScoreSubmitter submit = new ScoreSubmitter();
        submit.SubmitScore();
        SceneManager.LoadScene("4Exit");
    }
}
