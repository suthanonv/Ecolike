using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    [SerializeField] GameObject Effect;
    [SerializeField] float EffectUpTime;
    float Damage;
    [SerializeField] Element ProjectilEm;
    [SerializeField] ElementType type;
    [SerializeField] ElementalBaseDamageStat stat;
    [SerializeField] float DamageMultiple;

    private void Start()
    {
        Damage = stat.GetBaseDamage(type).baseDamage * (DamageMultiple / 100);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyAttacking>() != null)
        {
            collision.GetComponent<EnemyAttacking>().TakeDamage(Damage, type);
            SpawnEffect(collision.gameObject.transform);
        }

        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.GetComponent<EnemyHealth>().SetOxidation();
            collision.GetComponent<EnemyHealth>().TakeDamage(Damage, type);
          collision.GetComponent<EnemyHealth>().ReleaseReduction(ProjectilEm);
            SpawnEffect(collision.gameObject.transform);
        }

        if (collision.gameObject.GetComponent<Knockback>() != null && collision.gameObject.tag != "Player")
        {
            collision.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
            SpawnEffect(collision.gameObject.transform);
        }
    }

    void SpawnEffect(Transform Point)
    {
     GameObject Effects = Instantiate(Effect, Point.transform.position, Quaternion.identity);
        Destroy(Effects, EffectUpTime);
        Destroy(this.gameObject);
    }
}
