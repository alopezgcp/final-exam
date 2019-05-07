public class ScoreSubmitter
{
    public void SubmitScore()
    {
        int score = Stats.score;

        string newEntry = score.ToString() + "," + Stats.playerName; //e.g. "1350,myName"
        FileManager fm = new FileManager();
        fm.WriteScoreToFile(newEntry);
    }
}
