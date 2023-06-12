using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float destroyPointY;
    [SerializeField] private bool isBomb;
    private GameObject gameHandler;
    private GameObject chest;

    private void Start()
    {
        chest = GameObject.Find("MainChest");
        gameHandler = GameObject.Find("GameHandler");
    }

    // Update is called once per frame
    void Update()
    {
        //Move object down
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        //Rotate fruit on its y axis
        if (!isBomb)
        {
            transform.localRotation *= Quaternion.AngleAxis(100 * Time.deltaTime, Vector3.forward);
        }
        if (transform.position.y <= destroyPointY)
        {
            // when the object hits its lowest point (destroyPointY), it checks if the chest is near enough to trigger an action
            if (Vector3.Distance(transform.position, chest.transform.position) <= gameHandler.GetComponent<ScoreKeeper>().minDistancePoint)
            {
                if (!isBomb && chest.GetComponent<ChestController>().chestOpen)
                {
                    gameHandler.GetComponent<ScoreKeeper>().points += 1;
                }
                else if (isBomb && chest.GetComponent<ChestController>().chestOpen)
                {
                    gameHandler.GetComponent<ScoreKeeper>().lifes -= 1;
                    if (gameHandler.GetComponent<ScoreKeeper>().lifes == 0)
                    {
                        gameHandler.GetComponent<ScoreKeeper>().GameOver();
                    }
                }
            }
            Destroy(transform.gameObject);
        }
    }
}
