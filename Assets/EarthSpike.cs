using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpike : Reaction
{
    [SerializeField] float StundeingTime;
    [SerializeField] float DamageMultiple;
    EnemyHealth enemy;
    StatusEffect effect;
    [SerializeField] ElementalBaseDamageStat BaseDamage;
    [SerializeField] ElementType type;
    public override void SetReaction(GameObject Target)
    {
        enemy = Target.GetComponent<EnemyHealth>();
        effect = Target.GetComponent<StatusEffect>();
        float Damage = DamageMultiple * (BaseDamage.GetBaseDamage(type).baseDamage / 100);
        if (enemy != null)
        {
            enemy.TakeDamage(Damage, type);
            if (!effect.isStun())
            {
                effect.OnStun();
                StartCoroutine(UnStune());
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

    IEnumerator UnStune()
    {
        yield return new WaitForSeconds(StundeingTime);
        if (effect != null)
        {
            effect.OffStun();
        }
        Destroy(this.gameObject);
    }


    
}
