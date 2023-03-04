using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GolemAttack : MonoBehaviour
{
    Transform CheckTransform;
    [SerializeField] Animator anim;
    [SerializeField] float Atkrange;
    [SerializeField] float AttackCooldown;

    [SerializeField] public UnityEvent OnAttack,OffAttack;
    [SerializeField] public UnityEvent OnRange, OffRange;
    float CurrentCD;
   public void SetTransform(Transform newTransform)
    {
        CheckTransform = newTransform;
    }



    private void Update()
    {
        if(CheckTransform != null)
        {

            if (Vector2.Distance(this.transform.position, CheckTransform.transform.position) <= Atkrange)
            {
                OnRange.Invoke();
                if (CurrentCD <= 0)
                {
                    anim.SetBool("Attack", true);
                    CurrentCD = AttackCooldown;
                }
            }
            else
            {
                OffRange.Invoke();
            }
        }
        else
        {
            OffRange.Invoke();
        }
        if (CurrentCD > 0)
        {
            CurrentCD -= Time.deltaTime;
        }
    }
        
    }

