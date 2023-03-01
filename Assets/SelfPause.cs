using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SelfPause : MonoBehaviour
{
    [SerializeField] UnityEvent isPauseing, notPauseing;
    public void Start()
    {
        globalPause.instance.Paused.AddListener(Pausing);
    }

    public void Pausing(bool isPaused)
    {
        if(isPaused)
        {
            isPauseing.Invoke();
        }
        else
        {
            notPauseing.Invoke();
        }
    }

    private void OnDestroy()
    {
        globalPause.instance.Paused.RemoveListener(Pausing);
    }
}
