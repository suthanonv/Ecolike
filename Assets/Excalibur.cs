using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excalibur : MonoBehaviour
{
    [SerializeField] GameObject Parent;
    [SerializeField] Collider2D col;
    [SerializeField] Element element;
    [SerializeField] ElementType type;
    [SerializeField] float DamageMultiple;
    [SerializeField] ElementalBaseDamageStat stat;
    [SerializeField] Burn BurnEffect;
    [SerializeField] float chanceToBurn;
    float Damage;
    private void Start()
    {
        EffectManager.instance.OnExcalibur.Invoke();
        Damage = stat.GetBaseDamage(type).baseDamage * (DamageMultiple / 100);
    }

    public void DisableAttack()
    {
        col.enabled = false;
    }
    public void EnabledAttack()
    {
        col.enabled = true;
    }

    public void DestroyingSelf()
    {
        EffectManager.instance.OffExCalibur.Invoke();
        Destroy(Parent);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<EnemyHealth>().EmAttackType(element);
            other.GetComponent<EnemyHealth>().TakeDamage(Damage, type);
            other.GetComponent<EnemyHealth>().SetReduction(element);
            RandBurn(other.gameObject);
        }
    }

    void RandBurn(GameObject i)
    {
        float Randdom = Random.Range(1, 101);
        if(Randdom <= chanceToBurn)
        {
            Burn burned = Instantiate(BurnEffect,this.transform.position,Quaternion.identity);
            burned.SetReaction(i);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.gameObject.GetComponent<Knockback>() != null)
        {
            collision.gameObject.GetComponent<Knockback>().NormleFeedBack(Parent.gameObject);
        }
    }



}
