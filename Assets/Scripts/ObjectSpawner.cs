using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Transform[] pipesL1InstPoints;
    [SerializeField] private Transform[] pipesL2InstPoints;
    [SerializeField] private Transform[] pipesL3InstPoints;
    [SerializeField] private GameObject[] pipesParent;
    [SerializeField] private int[] pipesLevelTrigger;
    private Transform[][] pipeSpawn;
    [SerializeField] private Vector2[] spawnRate;
    private ScoreKeeper scoreKeeper;
    public bool gameStarted = false;
    [SerializeField] private int[] pointsForSpeedIncrese;
    [SerializeField] private float speedIncrease;
    public float destroyPoint;
    private int currentSpeedLevel = -1;
    private int currentSpawnRate = -1;
    public float speed;
    private bool[] spawnStates;
    private int pipeLevel = 0;
    private bool pipeL2Reached = false;
    private bool pipeL3Reached = false;

    private void Start()
    {
        pipeSpawn = new Transform[3][] {pipesL1InstPoints, pipesL2InstPoints, pipesL3InstPoints};
        pipesParent[pipeLevel].SetActive(true);
        scoreKeeper = GetComponent<ScoreKeeper>();
        spawnStates = new bool[pipeSpawn[pipeLevel].Length];
        for (int i = 0; i < pipeSpawn[pipeLevel].Length; i++)
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
        for (int i = 0; i < pipeSpawn[pipeLevel].Length; i++)
        {
            if (spawnStates[i])
            {
                int obj = Random.Range(0, objects.Length - 1);
                if (obj >= 10)
                { Instantiate(objects[obj], pipeSpawn[pipeLevel][i].position, Quaternion.Euler(0, 180, 45)).transform.parent = transform; }
                else
                { Instantiate(objects[obj], pipeSpawn[pipeLevel][i].position, Quaternion.Euler(-90, 0, 0)).transform.parent = transform; }
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

    public void SpawnsCanMove(bool canMove)
    {
        if (canMove)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
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

        //handle pipe amount increase
        if (scoreKeeper.points >= pipesLevelTrigger[0] && !pipeL2Reached)
        {
            pipeLevel = 1;
            pipesParent[pipeLevel].SetActive(true);
            pipesParent[pipeLevel - 1].SetActive(false);
            pipeL2Reached = true;
            StopAllCoroutines();
            spawnStates = new bool[pipeSpawn[pipeLevel].Length];
            for (int i = 0; i < pipeSpawn[pipeLevel].Length; i++)
            {
                spawnStates[i] = true;
            }
        }
        if (scoreKeeper.points >= pipesLevelTrigger[1] && !pipeL3Reached)
        {
            pipeLevel = 2;
            pipesParent[pipeLevel].SetActive(true);
            pipesParent[pipeLevel - 1].SetActive(false);
            pipeL3Reached = true;
            StopAllCoroutines();
            spawnStates = new bool[pipeSpawn[pipeLevel].Length];
            for (int i = 0; i < pipeSpawn[pipeLevel].Length; i++)
            {
                spawnStates[i] = true;
            }
        }
    }

}
