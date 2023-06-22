using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ClaimGoldReward : MonoBehaviour
{
    private string waitTime = "00:00:10.0000000";
    private bool updatedCounter = false;
    [SerializeField] private Text waitUntilLabel;
    [SerializeField] private Text yourGoldLabel;

    public void ClaimGold()
    {
        PlayerPrefs.SetString("goldRewardTimestamp", System.DateTime.Now.ToString());
        PlayerPrefs.SetInt("gold", 100 + PlayerPrefs.GetInt("gold"));
        GetComponent<Button>().interactable = false;
        yourGoldLabel.text = "Your Gold: " + PlayerPrefs.GetInt("gold").ToString();
    }

    private void OnEnable()
    {
        yourGoldLabel.text = "Your Gold: " + PlayerPrefs.GetInt("gold").ToString();
        if (PlayerPrefs.GetString("goldRewardTimestamp") == "")
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
        updatedCounter = false;
    }

    private void Update()
    {
        if (PlayerPrefs.GetString("goldRewardTimestamp") != "")
        {
            if (!updatedCounter)
            {
                updatedCounter = true;
                UpdateGoldTimer();
                StartCoroutine(Wait(1));
            }
        }
    }

    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        updatedCounter = false;
    }

    private void UpdateGoldTimer()
    {
        TimeSpan diff = System.DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("goldRewardTimestamp"));
        TimeSpan diffRemaining = TimeSpan.Parse(waitTime) - diff;
        waitUntilLabel.text = "Claim again in: " + diffRemaining.ToString(@"hh\:mm\:ss");
        if (diff >= TimeSpan.Parse(waitTime))
        {
            waitUntilLabel.text = "You can claim your Reward!";
            PlayerPrefs.SetString("goldRewardTimestamp", "");
            GetComponent<Button>().interactable = true;
        }
    }
}
