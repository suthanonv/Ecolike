using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAble : MonoBehaviour
{
    public virtual void TakeDamage(float Damage)
    {
    }

    public virtual void RegenAble(float RegenAmount)
    {
    }

    public virtual void SetReduction(Element ElementIncome)
    { 
    }

    public virtual void  EmAttackType(Element type)
    {
    }

    public virtual void ReleaseReduction(Element ElemnetIncome)
    {
    }

    public virtual void Dubuffing(GameObject Target)
    {
    }
    public virtual void Buffing(GameObject Target)
    {
    }
}
