using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour
{
    [SerializeField] private GameObject HomeMenuCanvas;
    [SerializeField] private GameObject PlayScreenCanvas;
    [SerializeField] private GameObject HighScoreCanvas;
    [SerializeField] private GameObject HomeMenuAssets;
    [SerializeField] private GameObject HighScoreMenuAssets;

    [SerializeField] private UpdateHighScores loadScores;

    public void HomeToHighscores()
    {
        HomeMenuCanvas.SetActive(false);
        HomeMenuAssets.SetActive(false);
        HighScoreCanvas.SetActive(true);
        HighScoreMenuAssets.SetActive(true);
        loadScores.UpdateScores();
    }

    public void HighscoresToHome()
    {
        HomeMenuCanvas.SetActive(true);
        HomeMenuAssets.SetActive(true);
        HighScoreCanvas.SetActive(false);
        HighScoreMenuAssets.SetActive(false);
    }
}
