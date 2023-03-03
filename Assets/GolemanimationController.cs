using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemanimationController : MonoBehaviour
{
  [SerializeField]  Animator anim;
    [SerializeField] GolemAttack attack;
    [SerializeField] GameObject AttackPoint;
    public void StopAttack()
    {
        anim.SetBool("Attack", false);
        attack.OffAttack.Invoke();
    }

    public void OnAtack()
    {
        AttackPoint.SetActive(true);
        
    }

}
