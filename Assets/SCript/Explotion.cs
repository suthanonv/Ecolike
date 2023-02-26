using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : Reaction
{
    [SerializeField] float ExplotionRange;
    [SerializeField] ElementalBaseDamageStat BaseDamageStat;
    [SerializeField] float DamageMultiple;
    [SerializeField] ElementType type;


    public override void SetReaction(GameObject Target)
    {
        EnemyHealth[] enemy = GameObject.FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth i in enemy)
        {
            if (Vector2.Distance(i.transform.position, this.transform.position) <= ExplotionRange)
            {
                float Damage = BaseDamageStat.GetBaseDamage(type).CurrentBaseDamage * (DamageMultiple / 100);
                i.TakeDamage(Damage, type);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
