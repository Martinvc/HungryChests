using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public float minDistancePoint;
    [HideInInspector] public int points;
    [HideInInspector] public int lifes;
    [SerializeField] private int gameLifes;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text lifesText;
    [SerializeField] private MenuNavigator menuNavigator;
    [SerializeField] private ObjectSpawner objectSpawner;
    public GameObject chest;
    [HideInInspector] public int[] highScores;

    private void Start()
    {
        // When the game starts the game logic is paused, this is helpful for menu handling
        Time.timeScale = 0;
        points = 0;
        lifes = gameLifes;
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
        Time.timeScale = 0;
        SaveScores();
        menuNavigator.ShowGameOverScreen();
    }

    public void startGame()
    {
        points = 0;
        lifes = gameLifes;
        Time.timeScale = 1;
        chest.transform.position = new Vector3(0, chest.transform.position.y, chest.transform.position.z);
        DeleteSpawns();
        GameStarted(true);
    }

    public void RestartGame()
    {
        menuNavigator.HideGameOverScreen();
        chest.transform.position = new Vector3(0, chest.transform.position.y, chest.transform.position.z);
        DeleteSpawns();
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

    public void SaveScores()
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
            else if (points == highScores[i])
            {
                return;
            }
            else if (points > highScores[i])
            {
                highScores[i] = points;
                PlayerPrefs.SetInt("score_" + i.ToString(), points);
                break;
            }
        }
    }

    public void DeleteSpawns()
    {
        objectSpawner.deleteSpawns();
    }

    public void GameStarted(bool state)
    {
        objectSpawner.gameStarted = state;
    }

}
