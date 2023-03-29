using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private string currentUser;
    private string bestScoreUsername;
    private int bestScorePoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            LoadBestScore();
            DontDestroyOnLoad(instance);
        }
    }

    public string CurrentUser
    {
        get { return currentUser; }
        set { currentUser = value; }
    }

    public string BestScoreUsername
    {
        get { return bestScoreUsername; }
        set { bestScoreUsername = value; }
    }

    public int BestScorePoints
    {
        get { return bestScorePoints; }
        set { bestScorePoints = value; }
    }

    public void UpdateBestScoreData(int points)
    {
        bestScoreUsername = currentUser;
        bestScorePoints = points;
        SaveBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestScoreUsername;
        public int bestScorePoints;
    }

    public void SaveBestScore()
    {
        SaveData saveData = new SaveData();
        saveData.bestScoreUsername = bestScoreUsername;
        saveData.bestScorePoints = bestScorePoints;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreUsername = data.bestScoreUsername;
            bestScorePoints = data.bestScorePoints;
        }
    }
}
