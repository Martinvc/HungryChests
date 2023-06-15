using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCheastOpenClose : MonoBehaviour
{
    [SerializeField] private Animancer.AnimancerComponent Animancer;
    [SerializeField] private AnimationClip AnimationOpen;
    [SerializeField] private AnimationClip AnimationClose;

    public void PlayOpenAnimation()
    { 
        Animancer.Play(AnimationOpen); 
    }

    public void PlayCloseAnimation()
    {
        Animancer.Play(AnimationClose);
    }
}
