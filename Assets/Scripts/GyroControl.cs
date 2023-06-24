using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroControl : MonoBehaviour
{
    [SerializeField] private string gyroOnMessage;
    [SerializeField] private string gyroOffMessage;
    [SerializeField] private Text gyroLabelText;
    [SerializeField] private ChestController chest;
    private Toggle toggle;
    private bool isToggleGyro = false;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        if (PlayerPrefs.GetInt("useGyro") == 0)
        {
            isToggleGyro = false;
            toggle.isOn = false;
            chest.useGyro = false;
        }
        else
        {
            isToggleGyro = true;
            toggle.isOn = true;
            chest.useGyro = true;
        }
    }

    public void valueChanged()
    {
        isToggleGyro = toggle.isOn;
        chest.useGyro = isToggleGyro;
        if (isToggleGyro)
        {
            PlayerPrefs.SetInt("useGyro", 1);
            gyroLabelText.text = gyroOnMessage;
        }
        else
        {
            PlayerPrefs.SetInt("useGyro", 0);
            gyroLabelText.text = gyroOffMessage;
        }
    }
}
