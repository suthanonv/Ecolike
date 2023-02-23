using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : DamageAble
{
    public virtual void ONStatChange(bool changeToNormle)
    {
    }

    public override void TakeDamage(float Damage, ElementType incomeType)
    {
        base.TakeDamage(Damage, incomeType);
    }

    public virtual void Skill()
    {
    }
}
