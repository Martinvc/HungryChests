using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterChest : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
