using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SmokeAttack : MonoBehaviour
{
    bool Active;
    [SerializeField] float CD;
    float CurrentCD;
    [SerializeField] UnityEvent OnFirstSkill, OffSkill;
    [SerializeField] float SkillActiveTime;
    float CoolCounter;
    [SerializeField] Animator anim;
    public void OnSkill(bool Active)
    {
        if(Active)
        {
            this.Active = true;
        }
        else
        {
            this.Active = false;
        }
    }


    private void Update()
    {
        if(Active)
        {
            if(CurrentCD <=  0)
            {
                OnFirstSkill.Invoke();
                anim.SetBool("Attack",true);
                CoolCounter = SkillActiveTime;
                CurrentCD = CD;
            }
        }
        if(CurrentCD > 0)
        {
            CurrentCD -= Time.deltaTime;
        }
        if(CoolCounter > 0)
        {
            CoolCounter -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("Attack", false);
            OffSkill.Invoke();
        }
    }


}
