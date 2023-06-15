using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHighScores : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI firstScoreLabel;
    [SerializeField] private TMPro.TextMeshProUGUI secondScoreLabel;
    [SerializeField] private TMPro.TextMeshProUGUI thirdScoreLabel;

    public void UpdateScores()
    {
        firstScoreLabel.text = "1st: " + PlayerPrefs.GetInt("score_0").ToString();
        secondScoreLabel.text = "2nd: " + PlayerPrefs.GetInt("score_1").ToString();
        thirdScoreLabel.text = "3rd: " + PlayerPrefs.GetInt("score_2").ToString();
    }
}
