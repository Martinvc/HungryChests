using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Transform[] pipeSpawn;
    [SerializeField] private Vector2[] spawnRate;
    private ScoreKeeper scoreKeeper;
    public bool gameStarted = false;
    [SerializeField] private int[] pointsForSpeedIncrese;
    [SerializeField] private float speedIncrease;
    private int currentSpeedLevel = -1;
    private int currentSpawnRate = -1;
    public float speed;
    private bool[] spawnStates;

    private void Start()
    {
        scoreKeeper = GetComponent<ScoreKeeper>();
        spawnStates = new bool[pipeSpawn.Length];
        for (int i = 0; i < pipeSpawn.Length; i++)
        {
            spawnStates[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            HandleLevelIncrease();
            startSpawning();
        }
    }

    IEnumerator Wait(int pipe)
    {

        yield return new WaitForSeconds(Random.Range(spawnRate[currentSpawnRate].x, spawnRate[currentSpawnRate].y));

        spawnStates[pipe] = true;

    }

    private void startSpawning()
    {
        for (int i = 0; i < pipeSpawn.Length; i++)
        {
            if (spawnStates[i])
            {
                int obj = Random.Range(0, objects.Length - 1);
                if (obj >= 10)
                { Instantiate(objects[obj], pipeSpawn[i].position, Quaternion.Euler(0, 180, 45)).transform.parent = transform; }
                else
                { Instantiate(objects[obj], pipeSpawn[i].position, Quaternion.Euler(-90, 0, 0)).transform.parent = transform; }
                spawnStates[i] = false;
                StartCoroutine(Wait(i));
            }
        }
    }

    public void deleteSpawns()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        currentSpeedLevel = -1;
        currentSpawnRate = -1;
        speed = 2;
    }

    private void HandleLevelIncrease()
    {
        if (currentSpeedLevel == -1)
        {
            currentSpeedLevel += 1;
            currentSpawnRate += 1;
        }
        else if (currentSpeedLevel < pointsForSpeedIncrese.Length && scoreKeeper.points >= pointsForSpeedIncrese[currentSpeedLevel])
        {
            speed += speedIncrease;
            currentSpeedLevel += 1;
            if (currentSpeedLevel < pointsForSpeedIncrese.Length)
            {
                currentSpawnRate += 1;
            }
        }
    }
}
