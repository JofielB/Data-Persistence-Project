using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScorePannelManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        if (DataManager.instance != null && DataManager.instance.BestScorePoints > 0)
        {
            bestScoreText.text =
                DataManager.instance.BestScoreUsername
                + " "
                + DataManager.instance.BestScorePoints;
        }
    }
}
