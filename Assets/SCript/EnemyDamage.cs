using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] UnityEvent OnHit;
    [SerializeField] float Damage = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnHit.Invoke();
            collision.gameObject.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
            this.gameObject.GetComponent<Knockback>().PlayFeedBack(collision.gameObject);
            collision.gameObject.GetComponent<DamageAble>().TakeDamage(Damage);
        }
    }
}
