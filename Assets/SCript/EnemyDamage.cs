using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyDamage : EnemyAttacking
{
    [SerializeField] UnityEvent OnHit;
    [SerializeField] float Damage = 10f;
    [SerializeField] StatHolder Stat;
    [SerializeField] ElementType type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnHit.Invoke();
            collision.gameObject.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
            this.gameObject.GetComponent<Knockback>().PlayFeedBack(collision.gameObject);
            collision.gameObject.GetComponent<DamageAble>().TakeDamage(Damage, type);
        }
    }

    public override void ONStatChange(bool ChangeToNormle)
    {
       if(ChangeToNormle)
        {
            Damage = Stat.BaseCharacterDamage.BaseMeleeDamage;
            Stat.BaseCharacterDamage.CurrentBaseMeleeDamage = Stat.BaseCharacterDamage.BaseMeleeDamage;
        }
       else
        {
            Damage = Stat.BaseCharacterDamage.CurrentBaseMeleeDamage;
        }
    }
}
