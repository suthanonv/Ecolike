using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashingDamage : MonoBehaviour
{
   
    [SerializeField] float EffectUpTime;
    [SerializeField] float Damage;
    [SerializeField] Element SlashElement;
    Transform Point;
    [SerializeField] ElementType Type;
 

    private void Start()
    {

        Shield.instance.CanAciveShield(false);
        Point = GameObject.FindWithTag("Weapon").transform;
        this.transform.parent = Point;
        this.transform.position = Point.transform.position;
        
        Destroy(this.gameObject, EffectUpTime);
    }

    private void Update()
    {
        this.transform.position = Point.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyAttacking>() != null)
        {
            collision.GetComponent<EnemyAttacking>().TakeDamage(Damage, Type);
        }

        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.GetComponent<EnemyHealth>().SetOxidation();
            collision.GetComponent<EnemyHealth>().TakeDamage(Damage, Type);
          //  collision.GetComponent<EnemyHealth>().ReleaseReduction(SlashElement);
        }

        if (collision.gameObject.GetComponent<Knockback>() != null && collision.gameObject.tag != "Player")
        {
            collision.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
        }
    }


    private void OnDestroy()
    {
        Shield.instance.CanAciveShield(true);
    }




}
