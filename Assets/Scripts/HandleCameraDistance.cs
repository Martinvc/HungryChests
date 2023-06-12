using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCameraDistance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeZPosition();
    }


    private void ChangeZPosition()
    {
        // This function will calculate the aspect ratio index , which is height/width
        float aspect_ratio = (float)(Screen.currentResolution.height) / Screen.currentResolution.width;

        // Hard-coded some values for the camera Z axis location based on the aspect ratio index, theres plenty of room for improvement here
        if (aspect_ratio <= 1.65f)
        {
            transform.position = new Vector3(0, 1, -10);
        }
        else if (aspect_ratio <= 1.8f)
        {
            transform.position = new Vector3(0, 1, -11);
        }
        else if (aspect_ratio <= 2.05f)
        {
            transform.position = new Vector3(0, 1, -12);
        }
        else if (aspect_ratio <= 2.3f)
        {
            transform.position = new Vector3(0, 1, -13);
        }
        else if (aspect_ratio <= 2.5f)
        {
            transform.position = new Vector3(0, 1, -14.5f);
        }
        else if (aspect_ratio <= 2.8f)
        {
            transform.position = new Vector3(0, 1, -16);
        }
    }
}
