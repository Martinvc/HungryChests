using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonCloseApp : MonoBehaviour
{
    [SerializeField] private MenuNavigator menuNavigator;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menuNavigator.HomeAppPopup("show");
        }
    }
}
