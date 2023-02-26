using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBlome : Reaction
{
    [SerializeField] float DamageMulitple;
    [SerializeField] ElementType type;
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
        float Damage = Maxhealth * (DamageMulitple / 100);
        if (enemy != null)
        {
            enemy.TakeDamage(Damage, type);
        }
        Destroy(this.gameObject);
    }
}
