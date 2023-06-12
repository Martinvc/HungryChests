using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Transform[] pipeSpawn;
    [SerializeField] private Vector2 spawnRate;
    private bool spawn1 = true;
    private bool spawn2 = true;
    private bool spawn3 = true;
    public bool gameStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            startSpawning();
        }
    }

    IEnumerator Wait(string pipe)
    {

        yield return new WaitForSeconds(Random.Range(spawnRate.x, spawnRate.y));

        if (pipe == "1")
        {
            spawn1 = true;
        }

        if (pipe == "2")
        {
            spawn2 = true;
        }

        if (pipe == "3")
        {
            spawn3 = true;
        }

    }

    private void startSpawning()
    {
        // 3 hard-coded pipes that will spawn a random object (fruit or bomb), the spawn rate is a random between spawnRate.x and spawnRate.y
        if (spawn1)
        {
            int obj = Random.Range(0, objects.Length - 1);
            if (obj >= 10)
            { Instantiate(objects[obj], pipeSpawn[0].position, Quaternion.Euler(0, 180, 45)).transform.parent = transform; }
            else
            { Instantiate(objects[obj], pipeSpawn[0].position, Quaternion.Euler(-90, 0, 0)).transform.parent = transform; }
            spawn1 = false;
            StartCoroutine(Wait("1"));
        }

        if (spawn2)
        {
            int obj = Random.Range(0, objects.Length - 1);
            if (obj >= 10)
            { Instantiate(objects[obj], pipeSpawn[1].position, Quaternion.Euler(0, 180, 45)).transform.parent = transform; }
            else
            { Instantiate(objects[obj], pipeSpawn[1].position, Quaternion.Euler(-90, 0, 0)).transform.parent = transform; }
            spawn2 = false;
            StartCoroutine(Wait("2"));
        }

        if (spawn3)
        {
            int obj = Random.Range(0, objects.Length - 1);
            if (obj >= 10)
            { Instantiate(objects[obj], pipeSpawn[2].position, Quaternion.Euler(0, 180, 45)).transform.parent = transform; }
            else
            { Instantiate(objects[obj], pipeSpawn[2].position, Quaternion.Euler(-90, 0, 0)).transform.parent = transform; }
            spawn3 = false;
            StartCoroutine(Wait("3"));
        }
    }

    public void deleteSpawns()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
