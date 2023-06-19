using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueHandler : MonoBehaviour
{
    [SerializeField] private string saveValueName;
    [SerializeField] private ChestController[] chestController;
    [SerializeField] private float defaultValue;
    private Text valueText;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        valueText = transform.Find("ValueText").GetComponent<Text>();
        slider = GetComponent<Slider>();
        if (PlayerPrefs.GetFloat(saveValueName) == 0)
        {
            PlayerPrefs.SetFloat(saveValueName, defaultValue);
            valueText.text = defaultValue.ToString();
            slider.value = defaultValue;
        }
        else
        {
            valueText.text = PlayerPrefs.GetFloat(saveValueName).ToString();
            slider.value = PlayerPrefs.GetFloat(saveValueName);
        }
    }

    // Update is called once per frame
    public void UpdateSliderValue()
    {
        PlayerPrefs.SetFloat(saveValueName, slider.value);
        valueText.text = slider.value.ToString();
        foreach (ChestController chest in chestController)
        {
            chest.ChangeChestSpeed(slider.value);
        }
    }

    
}
