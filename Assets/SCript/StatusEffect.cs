using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    public virtual void OnFreeze()
    {
      
    }
    public virtual bool isFreeze()
    {
        return false;
    }

    public virtual void OffFreeze()
    {

    }

    public virtual void OnStun()
    {

    }

    public virtual bool isStun()
    {
        return false;
    }

    public virtual void OffStun()
    {

    }

    public virtual void OnSlow()
    {

    }
    public virtual bool isSlow()
    {
        return false;
    }
    public virtual void OffSlow()
    {

    }

    public virtual void OnBurn()
    {

    }
    public virtual bool isBurn()
    {
        return false;
    }
    public virtual void OffBurn()
    {

    }


    public virtual void OnWeak()
    {

    }
    public virtual bool isWeak()
    {
        return false;
    }
    public virtual void OffWeak()
    {

    }

    public virtual void OnBleedActive()
    {

    }
    public virtual bool isBleed()
    {
        return false;
    }
    public virtual void OffBleedActive()
    {

    }

    public virtual void OnSuck()
    {

    }
    public virtual void SetSuckTransform(Transform suckedPoint)
    {

    }

    public virtual void OffSuck()
    {

    }
}
