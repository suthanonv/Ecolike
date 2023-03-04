using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SelfPause : MonoBehaviour
{
    [SerializeField] UnityEvent isPauseing, notPauseing,globalPusaeing;
    public void Start()
    {
        globalPause.instance.Paused.AddListener(Pausing);
        globalPause.instance.globalPaused.AddListener(globalPaused);
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

    public void globalPaused(bool ispause)
    {
        if (ispause)
        {
            globalPusaeing.Invoke();
        }
        else
        {
            notPauseing.Invoke();
        }
    }

    private void OnDestroy()
    {
        globalPause.instance.Paused.RemoveListener(Pausing);
        globalPause.instance.globalPaused.RemoveListener(globalPaused);
    }
}
