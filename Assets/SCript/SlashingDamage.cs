using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashingDamage : MonoBehaviour
{
   
    [SerializeField] float EffectUpTime;
    [SerializeField] float Damage;
    Transform Point;
 
 

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
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<DamageAble>().TakeDamage(Damage);
            collision.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
        }
        if (collision.gameObject.GetComponent<DamageAble>() != null && collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Player")
        {
            collision.GetComponent<DamageAble>().TakeDamage(Damage);
         
        }
    }


    private void OnDestroy()
    {
        Shield.instance.CanAciveShield(true);
    }




}
