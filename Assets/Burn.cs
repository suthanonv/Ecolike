using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Reaction
{
    StatusEffect effect;
    [SerializeField] ElementType type;
    EnemyHealth enemy;
    [SerializeField] float burnTime;
    [SerializeField] ElementalBaseDamageStat BaseDamage;
    [SerializeField] float DamageMultiple;
    float CalDamage;
    public override void SetReaction(GameObject Target)
    {
        effect = Target.GetComponent<StatusEffect>();
        enemy = Target.GetComponent<EnemyHealth>();
        CalDamage = BaseDamage.GetBaseDamage(type).baseDamage;
        if (effect != null)
        {
            if(!effect.isBurn())
            {
                effect.OnBurn();
                StartCoroutine(Burning());
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Burning()
    {
        float count = 0;
        while(count < burnTime)
        {
            yield return new WaitForSeconds(1);
            if(enemy!= null)
            {
                float Damage = CalDamage * (DamageMultiple / 100);
                enemy.TakeDamage(Damage, type);
            }
            else
            {
                Destroy(this.gameObject);
            }
            count++;
        }
        if(effect!= null)
        {
            effect.OffBurn();
        }
        Destroy(this.gameObject);
    }


}
