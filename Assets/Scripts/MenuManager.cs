using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    private static string playerName;
    private static int highScore;
    private static string highScoreName;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            return;
        }
    }
    public static void SaveName(string name)
    {
        playerName = name;
    }
    public static string LoadName()
    {
        return playerName;
    }
    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScoreName;
    }
    public static int GetHighScore()
    {
        return highScore;
    }
    public static void SetHighScore(int score)
    {
        highScore = score;
    }
    public static string GetHighScoreName()
    {
        return highScoreName;
    }
    public static void SetHighScoreName(string name)
    {
        highScoreName = name;
    }
    public static void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScore = highScore;
        data.HighScoreName = highScoreName;
        string dataInJson = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", dataInJson);
    }
    public static void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string dataInJson = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(dataInJson);
            highScore = data.HighScore;
            highScoreName = data.HighScoreName;
        }
        else
        {
            highScore = 0;
            highScoreName = "N/A";
        }
    }
}
