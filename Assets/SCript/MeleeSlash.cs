using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSlash : MonoBehaviour
{
    RotationToMouse rotate;
    [SerializeField] float DestoryTime;
    [SerializeField] float Damage;
    [SerializeField] Element SlashEm;
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
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<DamageAble>().TakeDamage(Damage);
            other.GetComponent<Knockback>().PlayFeedBack(this.gameObject);
        }
        if (other.gameObject.GetComponent<DamageAble>() != null && other.gameObject.tag != "Enemy" && other.gameObject.tag != "Player")
        {
            other.GetComponent<DamageAble>().TakeDamage(Damage);

        }
    }

    private void OnDestroy()
    {
        MeleeAttack.instace.DisalbespirteAndLight(false);
        PlayerWalk.instance.StopWalk(false);
        rotate.enabled = true;

    }

}
