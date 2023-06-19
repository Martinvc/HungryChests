using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private GameObject chest;
    private float chestSpeed;
    [SerializeField] private Vector2 ChestSpeedMinMax;
    [SerializeField] private Transform limitLeft;
    [SerializeField] private Transform limitRight;
    [SerializeField] private MainCheastOpenClose cheastAnimator;
    [SerializeField] private bool isSettingsChest = false;
    private Touch touch;
    public bool chestOpenAnimation = false;
    public bool chestOpenState = false;


    private void Start()
    {
        if (PlayerPrefs.GetFloat("chestSpeed") == 0)
        {
            chestSpeed = convertRange(1, 30, ChestSpeedMinMax.x, ChestSpeedMinMax.y, 10);
            PlayerPrefs.SetFloat("chestSpeed", chestSpeed);
        }
        else
        {
            chestSpeed = PlayerPrefs.GetFloat("chestSpeed");
        }
    }
    void Update()
    {
        if (isSettingsChest)
        {
            SensitivityChestMove();
        }
        else
        {
            GamePlayChestMove();
        }
    }

    void openChest()
    {
        if (!chestOpenAnimation)
        {
            chestOpenAnimation = true;
            cheastAnimator.PlayOpenAnimation();
        }
    }

    void closeChest()
    {
        if (chestOpenAnimation)
        {
            chestOpenAnimation = false;
            cheastAnimator.PlayCloseAnimation();
        }
    }

    private void GamePlayChestMove()
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

    private void SensitivityChestMove()
    {
        if (Input.touchCount > 0 && (Input.GetTouch(0).position.y <= Screen.height / 3))
        {
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
    }

    public float convertRange(float originalRangeMin, float originalRangeMax, float newRangeMin, float newRangeMax, float value)
    {
        float outRange = Mathf.Abs(newRangeMax - newRangeMin);
        float inRange = Mathf.Abs(originalRangeMax - originalRangeMin);
        float range = (outRange / inRange);
        return (newRangeMin + (range * (value - originalRangeMin)));
    }

    public void ChangeChestSpeed(float value)
    {
        chestSpeed = convertRange(1, 30, ChestSpeedMinMax.x, ChestSpeedMinMax.y, value);
        PlayerPrefs.SetFloat("chestSpeed", chestSpeed);
    }
}
