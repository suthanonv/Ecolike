using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum stateOnOff
{
    on,off
}
public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;
    [Header("Utimate Effect")]
    [SerializeField] public UnityEvent OnUtimate,OffUtimate;
    [SerializeField] List<GameObject> effectPrefab;

    [Header("Excalibur")]
    [SerializeField] public UnityEvent OnExcalibur, OffExCalibur;

    [Header("BuffBody")]
    [SerializeField] public UnityEvent OnBodyBuffed, OffBodyBuff;
    
    private void Awake()
    {
        instance = this;
    }

    public void UtimateEffect(int num,stateOnOff state)
    {
            
        if(state == stateOnOff.off)
        {
            effectPrefab[num].SetActive(false);
            OffUtimate.Invoke();
        }
        else
        {
            effectPrefab[num].SetActive(true);
            OnUtimate.Invoke();
        }
    }

    public void OnBodyBuff(stateOnOff state)
    {
        if(state == stateOnOff.off)
        {
            OffBodyBuff.Invoke();
        }
        else
        {
            OnBodyBuffed.Invoke();
        }

    }




}
