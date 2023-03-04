using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemanimationController : MonoBehaviour
{
  [SerializeField]  Animator anim;
    [SerializeField] GolemAttack attack;

    public void StopAttack()
    {
        anim.SetBool("Attack", false);
    }


    public void OnAtack()
    {
        attack.OnAttack.Invoke();
    }

}
