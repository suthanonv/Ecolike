using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MeleeUtimate : MonoBehaviour
{
    [SerializeField] float MeleeUpTime;
    [SerializeField] UnityEvent OnDone;
    void Start()
    {
        globalPause.instance.Paused.Invoke(true); 
        EffectManager.instance.UtimateEffect(0, stateOnOff.on);
        Invoke("StopingMeleeUtimate", MeleeUpTime);
        this.transform.position = GameObject.FindWithTag("Player").transform.position;
    }

    private void StopingMeleeUtimate()
    {
        OnDone.Invoke();
        EffectManager.instance.UtimateEffect(0, stateOnOff.off);
        globalPause.instance.Paused.Invoke(false);
        Destroy(this.gameObject,0.25f);
    }
}
