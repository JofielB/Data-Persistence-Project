using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
