using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    [SerializeField] GameObject Effect;
    [SerializeField] float EffectUpTime;
    [SerializeField] float Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<DamageAble>().TakeDamage(Damage);
            SpawnEffect(collision.gameObject.transform);
        }
        if(collision.gameObject.tag == "Wall")
        {
            SpawnEffect(this.gameObject.transform);
        }
        if(collision.gameObject.GetComponent<DamageAble>() != null && collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Player")
        {
            collision.GetComponent<DamageAble>().TakeDamage(Damage);
            SpawnEffect(this.gameObject.transform);
        }
    }

    void SpawnEffect(Transform Point)
    {
     GameObject Effects = Instantiate(Effect, Point.transform.position, Quaternion.identity);
        Destroy(Effects, EffectUpTime);
        Destroy(this.gameObject);
    }
}
