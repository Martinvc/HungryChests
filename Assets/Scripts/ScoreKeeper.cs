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
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private GameObject chest;

    private void Start()
    {
        // When the game starts the game logic is paused, this is helpful for menu handling
        Time.timeScale = 0;
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
        restartButton.SetActive(true);
    }

    public void startGame()
    {
        playButton.SetActive(false);
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
}
