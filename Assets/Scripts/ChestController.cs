using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private GameObject chest;
    [SerializeField] private float chestSpeed;
    [SerializeField] private Transform limitLeft;
    [SerializeField] private Transform limitRight;
    [SerializeField] private Animator anim;
    private Touch touch;
    public bool chestOpen = false;
    // Update is called once per frame
    void Update()
    {
        // If the game detects input (touch) on the lowest 1/3 portion of the screen it will allow movement
        if (Input.touchCount > 0 && (Input.GetTouch(0).position.y <= Screen.height / 3))
        {
            openChest();
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                
                chest.transform.position = new Vector3(
                    chest.transform.position.x + touch.deltaPosition.x * chestSpeed * Time.deltaTime,
                    chest.transform.position.y,
                    chest.transform.position.z);
            }
            if (chest.transform.position.x <= limitLeft.position.x)
            {
                chest.transform.position = new Vector3(limitLeft.position.x, chest.transform.position.y, chest.transform.position.z);
            }
            if (chest.transform.position.x >= limitRight.position.x)
            {
                chest.transform.position = new Vector3(limitRight.position.x, chest.transform.position.y, chest.transform.position.z);
            }
        }
        else
        {
            closeChest();
        }
    }

    void openChest()
    {
        if (!chestOpen)
        {
            chestOpen = true;
            anim.SetTrigger("Open");
        }
    }

    void closeChest()
    {
        if (chestOpen)
        {
            chestOpen = false;
            anim.SetTrigger("Close");
        }
    }
}
