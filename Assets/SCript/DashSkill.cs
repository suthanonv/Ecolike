using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DashSkill : MonoBehaviour
{
    [SerializeField] SetKeyBinding key;
    [SerializeField] float DashSpeed;
    [SerializeField] float DashCoolDown = 1;
    float CurrentCoolDown;
    [SerializeField] float DashLenght;
    [SerializeField] Transform DashPosition;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] UnityEvent Ondash, OnDashdone;
    float AnimtaedCooldown;
    private void Update()
    {
        Vector3 direction = DashPosition.position - transform.position;
        direction.Normalize();
        dashment = direction;

        if (CurrentCoolDown <= 0)
        {
            UiManager.instance.SetBaseSkillCooldown(CurrentCoolDown);
            if (Input.GetKeyDown(key.WeapoNSkillKey))
            {
                Ondash.Invoke();
                DashMechanic(DashPosition.position);
                CurrentCoolDown = DashCoolDown;
                AnimtaedCooldown = DashCoolDown;
                UiManager.instance.BaseWeaponCooldown.fillAmount = 1;
            }
        }
        else
        {
            CurrentCoolDown -= Time.deltaTime;
            UiManager.instance.BaseWeaponCooldown.fillAmount -= 1 / AnimtaedCooldown * Time.deltaTime;
            UiManager.instance.SetBaseSkillCooldown(CurrentCoolDown);
        }
    }





    Vector2 dashment;
   void DashMechanic(Vector3 point)
    {
        Vector2 direction = (transform.position - point).normalized;
        rb.AddForce(direction * DashSpeed, ForceMode2D.Impulse);
        StartCoroutine(Reset(DashLenght));
    }

    IEnumerator Reset(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        rb.velocity = Vector3.zero;
        OnDashdone.Invoke();
    }


    private void OnEnable()
    {
        if(CurrentCoolDown > 0)
        {
            AnimtaedCooldown = CurrentCoolDown;
            UiManager.instance.BaseWeaponCooldown.fillAmount = CurrentCoolDown;
            UiManager.instance.SetBaseSkillCooldown(CurrentCoolDown);
        }
    }

}
