using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashingDamage : MonoBehaviour
{
   
    [SerializeField] float EffectUpTime;
    [SerializeField] float Damage;
    Transform Point;
    private void Awake()
    {
        SetWeaponColor.instance.OnStopRoate(true);
        PlayerWalk.instance.StopWalk(true);
        
    }

    private void Start()
    {

        Shield.instance.CanAciveShield(false);
        Point = GameObject.FindWithTag("Weapon").transform;
        this.transform.parent = Point;
        this.transform.position = Point.transform.position;
        SetWeaponColor.instance.DisableBall(false);
        Destroy(this.gameObject, EffectUpTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<DamageAble>().TakeDamage(Damage);
            collision.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        PlayerWalk.instance.StopWalk(false);
        Shield.instance.CanAciveShield(true);
        SetWeaponColor.instance.OnStopRoate(false);
        SetWeaponColor.instance.DisableBall(true);
    }


}
