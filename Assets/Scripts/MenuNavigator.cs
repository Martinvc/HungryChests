using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavigator : MonoBehaviour
{
    [SerializeField] private GameObject HomeMenuCanvas;
    [SerializeField] private GameObject PlayScreenCanvas;
    [SerializeField] private GameObject HighScoreCanvas;
    [SerializeField] private GameObject PauseMenuCanvas;
    [SerializeField] private GameObject SkinsMenuCanvas;
    [SerializeField] private GameObject SettingsMenuCanvas;
    [SerializeField] private GameObject SensitivityMenuCanvas;
    [SerializeField] private GameObject DailyRewardsMenuCanvas;
    [SerializeField] private GameObject HomeMenuAssets;
    [SerializeField] private GameObject HighScoreMenuAssets;
    [SerializeField] private GameObject PauseGameOverMenuAssets;
    [SerializeField] private GameObject SkinsMenuAssets;
    [SerializeField] private GameObject SettingsMenuAssets;
    [SerializeField] private GameObject SensitivityMenuAssets;
    [SerializeField] private GameObject GamePlayAssets;
    [SerializeField] private GameObject DailyRewardsMenuAssets;

    [SerializeField] private UpdateHighScores loadScores;
    [SerializeField] private ScoreKeeper scoreKeeper;

    private bool gamefocus = true;
    private bool onPlayScreen = false;

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            gamefocus = false;
        }
        else if (focus && !gamefocus && onPlayScreen)
        {
            gamefocus = true;
            GameToPauseScreen();
        }
    }
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

    public void GameOverToHome()
    {
        PlayScreenCanvas.SetActive(false);
        HomeMenuCanvas.SetActive(true);
        HomeMenuAssets.SetActive(true);
        scoreKeeper.GameStarted(false);
    }

    public void ShowGameOverScreen()
    {
        PlayScreenCanvas.transform.Find("RestartButton").gameObject.SetActive(true);
        PlayScreenCanvas.transform.Find("Game Over").gameObject.SetActive(true);
        PlayScreenCanvas.transform.Find("GoHomeButton").gameObject.SetActive(true);
        PlayScreenCanvas.transform.Find("PauseButton").gameObject.SetActive(false);
    }

    public void HideGameOverScreen()
    {
        PlayScreenCanvas.transform.Find("RestartButton").gameObject.SetActive(false);
        PlayScreenCanvas.transform.Find("Game Over").gameObject.SetActive(false);
        PlayScreenCanvas.transform.Find("GoHomeButton").gameObject.SetActive(false);
        PlayScreenCanvas.transform.Find("PauseButton").gameObject.SetActive(true);
    }

    public void PlayToStartGame()
    {
        HomeMenuAssets.SetActive(false);
        HomeMenuCanvas.SetActive(false);
        PlayScreenCanvas.SetActive(true);
        HideGameOverScreen();
        onPlayScreen = true;
        scoreKeeper.startGame();
    }

    public void GameToPauseScreen()
    {
        Time.timeScale = 0;
        PlayScreenCanvas.SetActive(false);
        PauseGameOverMenuAssets.SetActive(true);
        PauseMenuCanvas.SetActive(true);
        PauseMenuCanvas.transform.Find("Points").GetComponent<Text>().text = "Points: " + scoreKeeper.points.ToString();
        PauseMenuCanvas.transform.Find("Lifes").GetComponent<Text>().text = "Lifes: " + scoreKeeper.lifes.ToString();

    }

    public void ResumeToPlay()
    {
        PlayScreenCanvas.SetActive(true);
        PauseGameOverMenuAssets.SetActive(false);
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseScreenToHome()
    {
        scoreKeeper.SaveScores();
        scoreKeeper.DeleteSpawns();
        scoreKeeper.GameStarted(false);
        PauseGameOverMenuAssets.SetActive(false);
        PauseMenuCanvas.SetActive(false);
        HomeMenuCanvas.SetActive(true);
        HomeMenuAssets.SetActive(true);
        onPlayScreen = false;
    }

    public void PauseScreenRestartToPlay()
    {
        PlayScreenCanvas.SetActive(true);
        PauseGameOverMenuAssets.SetActive(false);
        PauseMenuCanvas.SetActive(false);
        scoreKeeper.RestartGame();
    }

    public void HomeToSkinsMenu()
    {
        HomeMenuCanvas.SetActive(false);
        HomeMenuAssets.SetActive(false);
        SkinsMenuCanvas.SetActive(true);
        SkinsMenuAssets.SetActive(true);
    }

    public void SkinsMenuToHome()
    {
        HomeMenuCanvas.SetActive(true);
        HomeMenuAssets.SetActive(true);
        SkinsMenuCanvas.SetActive(false);
        SkinsMenuAssets.SetActive(false);
    }

    public void HomeToSettings()
    {
        HomeMenuCanvas.SetActive(false);
        HomeMenuAssets.SetActive(false);
        SettingsMenuCanvas.SetActive(true);
        SettingsMenuAssets.SetActive(true);
    }

    public void SettingsToHome()
    {
        HomeMenuCanvas.SetActive(true);
        HomeMenuAssets.SetActive(true);
        SettingsMenuCanvas.SetActive(false);
        SettingsMenuAssets.SetActive(false);
    }

    public void SettingsToSensitivity()
    {
        SettingsMenuCanvas.SetActive(false);
        SettingsMenuAssets.SetActive(false);
        GamePlayAssets.SetActive(false);
        SensitivityMenuCanvas.SetActive(true);
        SensitivityMenuAssets.SetActive(true);
        Time.timeScale = 1;
    }

    public void SensitivityToSettings()
    {
        SettingsMenuCanvas.SetActive(true);
        SettingsMenuAssets.SetActive(true);
        GamePlayAssets.SetActive(true);
        SensitivityMenuCanvas.SetActive(false);
        SensitivityMenuAssets.SetActive(false);
    }

    public void HomeToDailyRewards()
    {
        HomeMenuCanvas.SetActive(false);
        HomeMenuAssets.SetActive(false);
        DailyRewardsMenuCanvas.SetActive(true);
        DailyRewardsMenuAssets.SetActive(true);
        Time.timeScale = 1;
    }

    public void DailyRewardsToHome()
    {
        HomeMenuCanvas.SetActive(true);
        HomeMenuAssets.SetActive(true);
        DailyRewardsMenuCanvas.SetActive(false);
        DailyRewardsMenuAssets.SetActive(false);
        Time.timeScale = 0;
    }
}
