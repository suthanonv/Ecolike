using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SmokeStatusEffect : StatusEffect
{
    bool isEffectBurn, isEffectFreeze, isEffectStune,isEffectSlow,isEffectWeak,isEffectBleed;
    [Header("Freeze")]
    [SerializeField] UnityEvent OnFreezed, OffFreezeed;
   
    [Header("Stuneing")]
    [SerializeField] UnityEvent OnStued, OffStuned;
   
    [Header("OnWeak")]
    [SerializeField] UnityEvent OnWeaked, OffWeaked;
    [SerializeField] float ReducedResis;
    float CurrentResis;
    [SerializeField] StatHolder holder;
   
    [Header("Suck")]
    [SerializeField] UnityEvent OnSukced,OffSucked;
    [SerializeField] Onsucking suckedSciprt;
    public override void OnFreeze()
    {
        isEffectFreeze = true;
        OnFreezed.Invoke();
    }
    public override bool isFreeze()
    {
        return isEffectFreeze;
    }

    public override void OffFreeze()
    {
        isEffectFreeze = false;
        OffFreezeed.Invoke();
    }

    public override void OnStun()
    {
        isEffectStune = true;
        OnStued.Invoke();
    }

    public override bool isStun()
    {
        return isEffectStune;
    }

    public override void OffStun()
    {
        isEffectStune = false;
    }

    public override void OnSlow()
    {
        isEffectSlow = true;
    }
    public override bool isSlow()
    {
        return isEffectSlow;
    }
    public override void OffSlow()
    {
        isEffectSlow = false;
    }

    public override void OnBurn()
    {
        isEffectBurn = true;
    }
    public override bool isBurn()
    {
        return isEffectBurn;
    }
    public override void OffBurn()
    {
        isEffectBurn = false;
    }


    public override void OnWeak()
    {
        isEffectWeak = true;
        CurrentResis = ReducedResis / 100;
       foreach(Resistance i in holder.BaseResistance)
        {
            i.ResistantAmount -= CurrentResis;
        }
    }
    public override bool isWeak()
    {
        return isEffectWeak;
    }
    public override void OffWeak()
    {
        isEffectWeak = false;
        CurrentResis = ReducedResis / 100;
        foreach (Resistance i in holder.BaseResistance)
        {
            i.ResistantAmount += CurrentResis;
        }
    }

    public override void OnBleedActive()
    {
        isEffectBleed = true;
    }
    public override bool isBleed()
    {
        return isEffectBleed;
    }
    public override void OffBleedActive()
    {
        isEffectBleed = false;
    }

    public override void OnSuck()
    {
        OnSukced.Invoke();
    }
    public override void SetSuckTransform(Transform suckedPoint)
    {
        suckedSciprt.SetTransform(suckedPoint);
    }

    public override void OffSuck()
    {
        OffSucked.Invoke();
        this.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
    }
}
