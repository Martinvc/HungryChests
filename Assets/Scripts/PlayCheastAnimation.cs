using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCheastAnimation : MonoBehaviour
{
    [SerializeField] private Animancer.AnimancerComponent Animancer;
    [SerializeField] private AnimationClip Animation;
    // Start is called before the first frame update
    private void OnEnable()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        Animancer.Play(Animation);
    }
}
