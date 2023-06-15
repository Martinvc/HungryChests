using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public float minDistancePoint;
    public int points = 0;
    public int lifes = 3;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text lifesText;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject HomeMenuCanvas;
    [SerializeField] private GameObject PlayScreenCanvas;
    [SerializeField] private GameObject HomeMenuAssets;
    public int[] highScores; 

    private void Start()
    {
        // When the game starts the game logic is paused, this is helpful for menu handling
        Time.timeScale = 0;
        highScores = new int[]{0, 0, 0};
        CheckSavedScores();
    }

    // Update is called once per frame
    void Update()
    {
        // Update points and lifes label text
        pointsText.text = "Points: " + points.ToString();
        lifesText.text = "Lifes: " + lifes.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
        SaveScores();
        restartButton.SetActive(true);
    }

    public void startGame()
    {
        HomeMenuAssets.SetActive(false);
        HomeMenuCanvas.SetActive(false);
        PlayScreenCanvas.SetActive(true);
        Time.timeScale = 1;
        objectSpawner.gameStarted = true;
    }

    public void RestartGame()
    {
        restartButton.SetActive(false);
        gameOver.SetActive(false);
        chest.transform.position = new Vector3(0, chest.transform.position.y, chest.transform.position.z);
        objectSpawner.deleteSpawns();
        points = 0;
        lifes = 3;
        Time.timeScale = 1;
    }

    private void CheckSavedScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            if (PlayerPrefs.GetInt("score_" + i.ToString()) == 0)
            {
                PlayerPrefs.SetInt("score_" + i.ToString(), 0);
            }
            else
            {
                highScores[i] = PlayerPrefs.GetInt("score_" + i.ToString());
            }
        }
    }

    private void SaveScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            if (points > highScores[i] && highScores[i] != 0)
            {
                for (int x = highScores.Length - 1; x >= 0; x--)
                {
                    if (x == i)
                    {
                        highScores[x] = points;
                        PlayerPrefs.SetInt("score_" + x.ToString(), points);
                        break;
                    }
                    highScores[x] = highScores[x - 1];
                    PlayerPrefs.SetInt("score_" + x.ToString(), highScores[x - 1]);
                }
                break;
            }
            else if (points > highScores[i])
            {
                highScores[i] = points;
                PlayerPrefs.SetInt("score_" + i.ToString(), points);
                break;
            }
        }
    }
}
