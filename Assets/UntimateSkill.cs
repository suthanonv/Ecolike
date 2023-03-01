using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UntimateSkill : MonoBehaviour
{
    [SerializeField] float SkillUpTime;
    [SerializeField] UnityEvent OnDone;
    void Start()
    {
        globalPause.instance.Paused.Invoke(true);
        EffectManager.instance.UtimateEffect(0, stateOnOff.on);
        Invoke("StopingUtimateSkill", SkillUpTime);
        this.transform.position = GameObject.FindWithTag("Player").transform.position;
    }

    private void StopingUtimateSkill()
    {
        OnDone.Invoke();
        EffectManager.instance.UtimateEffect(0, stateOnOff.off);
        globalPause.instance.Paused.Invoke(false);
        Destroy(this.gameObject, 0.25f);
    }
}
