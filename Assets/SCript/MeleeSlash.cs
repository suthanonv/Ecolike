using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSlash : MonoBehaviour
{
    RotationToMouse rotate;
    [SerializeField] float DestoryTime;
    [SerializeField] float Damage;
    [SerializeField] Element SlashEm;
    [SerializeField] ElementType type;
    private void Start()
    {
        PlayerWalk.instance.StopWalk(true);
        rotate = GameObject.FindWithTag("Weapon").GetComponent<RotationToMouse>();
        rotate.enabled = false;
        MeleeAttack.instace.DisalbespirteAndLight(true);
        Destroy(this.gameObject, DestoryTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyAttacking>() != null)
        {
            other.GetComponent<EnemyAttacking>().TakeDamage(Damage, type);
        } 
        if (other.gameObject.GetComponent<Knockback>() != null && other.gameObject.tag != "Player")
        {
            other.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
        }

        if (other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage, type);
            other.GetComponent<EnemyHealth>().EmAttackType(SlashEm);
            other.GetComponent<EnemyHealth>().SetReduction(SlashEm);
        } 

       
    }

    private void OnDestroy()
    {
        MeleeAttack.instace.DisalbespirteAndLight(false);
        PlayerWalk.instance.StopWalk(false);
        rotate.enabled = true;

    }

}
