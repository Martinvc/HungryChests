using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCheastOpenClose : MonoBehaviour
{
    [SerializeField] private Animancer.AnimancerComponent Animancer;
    [SerializeField] private AnimationClip AnimationOpen;
    [SerializeField] private AnimationClip AnimationClose;
    [SerializeField] private bool isGamePlayChest = false;
    private ChestController chest;

    private void Start()
    {
        chest = transform.parent.gameObject.GetComponent<ChestController>();
    }
    public void PlayOpenAnimation()
    { 
        Animancer.Play(AnimationOpen); 
    }

    public void PlayCloseAnimation()
    {
        Animancer.Play(AnimationClose);
    }

    public void chestStateOpen()
    {
        if (isGamePlayChest)
        {
            chest.chestOpenState = true;
        }
    }

    public void chestStateClose()
    {
        if (isGamePlayChest)
        {
            chest.chestOpenState = false;
        }
    }
}
