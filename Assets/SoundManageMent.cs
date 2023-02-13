using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManageMent : MonoBehaviour
{
    public static SoundManageMent instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] AudioSource source,bsource,csource;
    [SerializeField] AudioClip BoxBroken,JarBroken;


    public void PlayBlockBroken()
    {
        bsource.clip = BoxBroken;
        bsource.Play();
    }
    
    public  void PLayJarBroken()
    {
        source.clip = JarBroken;
        source.Play();
    }

    public void PlayCustomSound(AudioClip clip)
    {
        csource.clip = clip;
        csource.Play();
    }


}
