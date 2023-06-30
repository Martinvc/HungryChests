using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSkinsScrollView : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
