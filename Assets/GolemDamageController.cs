using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDamageController : MonoBehaviour
{
    [SerializeField] ElementalBaseDamageStat baseState;
    [SerializeField] Element baseElement;
    [SerializeField] ElementType type;
    [SerializeField] float DamageMultiple;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().SetOxidation();
            float Damage = baseState.GetBaseDamage(type).baseDamage * (DamageMultiple / 100);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(Damage,type);
            collision.gameObject.GetComponent<EnemyHealth>().ReleaseReduction(baseElement);
        }
        if(collision.gameObject.GetComponent<Knockback>() != null)
        {
            collision.gameObject.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
        }
    }
}
