using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    
     AudioClip clip;
    [SerializeField] AudioClip FirstClip,SecondClip;
      
    public void PlaySound()
    {
        SoundManageMent.instance.PlayUtimateSound(clip);
    }

    public void StopMove()
    {
        PlayerWalk.instance.enabled = false;
    }
    public void SwapToClip1()
    {
        clip = FirstClip;
    }

    public void SwapToClip2()
    {
        clip = SecondClip;
    }

    public void stopSound()
    {
        SoundManageMent.instance.StopUtimateSound();
    }
}
