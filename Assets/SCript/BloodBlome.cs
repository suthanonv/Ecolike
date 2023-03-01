using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBlome : Reaction
{
    [SerializeField] float DamageMulitple;
    [SerializeField] ElementType type1,type2;
    [SerializeField] float MultipleEm1, MultipleEm2;
    [SerializeField] ElementalBaseDamageStat stat;
    EnemyHealth enemy;
    [SerializeField] float ActiveTime;
    float Maxhealth;
    public override void SetReaction(GameObject Target)
    {
        enemy = Target.GetComponent<EnemyHealth>();
        Maxhealth = Target.GetComponent<StatHolder>().CharacterBaseStat.MaxHp;

        Invoke("Bloom", ActiveTime);
    }

    void Bloom()
    {
        float Damage = (DamageMulitple /100 )* ((stat.GetBaseDamage(type1).baseDamage * MultipleEm1) /100) * ((stat.GetBaseDamage(type2).baseDamage * MultipleEm2) /100);
        Debug.Log(Damage);
        if (enemy != null)
        {
            enemy.TakeDamage(Damage, type1);
        }
        Destroy(this.gameObject);
    }
}
