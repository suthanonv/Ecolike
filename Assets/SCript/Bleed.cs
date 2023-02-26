using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : Reaction
{
    [SerializeField] float Time = 10;
    [SerializeField] float DamageMulitple;
    [SerializeField] ElementType type;
    EnemyHealth enemy;
    StatusEffect efect;
    float Maxhealth;
    public override void SetReaction(GameObject Target)
    {
        efect = Target.GetComponent<StatusEffect>();
        enemy = Target.GetComponent<EnemyHealth>();
        Maxhealth = Target.GetComponent<StatHolder>().CharacterBaseStat.MaxHp;
        if (enemy != null)
        {
           if(!efect.isBleed()){
                efect.OnBleedActive();
                StartCoroutine(EffectActive());
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

    IEnumerator EffectActive()
    {
        int count = 0;
        while (count < Time)
        {
            yield return new WaitForSeconds(1);
            float Damage = Maxhealth * (DamageMulitple / 100);
            if (enemy != null) {
                enemy.TakeDamage(Damage, type);
            }
            else
            {
                Destroy(this.gameObject);
            }
            count++;
        }
        if (enemy != null)
        {
            efect.OffBleedActive();
        }
        Destroy(this.gameObject);
        }
    }

