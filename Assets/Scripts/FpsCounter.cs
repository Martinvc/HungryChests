using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    private float fps;
    [SerializeField] private Text fpsText;
    [SerializeField] private Text refreshRateText;
    // Start is called before the first frame update
    void Start()
    {
        // Put the screen refresh rate on the text label and set the target frame rate to the same value of refresh rate
        refreshRateText.text = "Screen Hz:" + Screen.currentResolution.refreshRate.ToString();
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    // Update is called once per frame
    void Update()
    {
        // Put the FPS counter result on its text label for easy reading
        fps = 1f / Time.deltaTime;
        fpsText.text = "FPS: " + fps.ToString();
    }
}
