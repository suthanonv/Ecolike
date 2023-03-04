using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class globalPause : MonoBehaviour
{
    public static globalPause instance;
    public UnityEvent<bool> Paused,globalPaused;
    private void Awake()
    {
        instance = this;
    }



}
