using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGoldLabel : MonoBehaviour
{
    
    private void OnEnable()
    {
        GetComponent<Text>().text = "Gold: " + PlayerPrefs.GetInt("gold").ToString();
    }
}
