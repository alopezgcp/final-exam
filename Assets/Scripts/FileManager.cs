using System.IO;
using System.Collections.Generic;

public class FileManager
{
    string path = "Assets/scores.txt";
    
    public List<string> GetScores()
    {
        List<string> scores = new List<string>();
        FileManager fm = new FileManager();
        string line = "";

        using (StreamReader sr = new StreamReader(path))
        {
            while ((line = sr.ReadLine()) != null)
            {
                scores.Add(line);
            }
        }

        return scores;
    }

    public void WriteScoreToFile(string newScore)
    {
        using(StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine(newScore);
        }
    }
}
