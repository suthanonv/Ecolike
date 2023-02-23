using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DashSkill : MonoBehaviour
{
    public KeyCode DashKey = KeyCode.F;
    [SerializeField] float DashSpeed;
    [SerializeField] float DashCoolDown = 1;
    float CurrentCoolDown;
    [SerializeField] float DashLenght;
    [SerializeField] Transform DashPosition;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] UnityEvent Ondash, OnDashdone;

    private void Update()
    {
        Vector3 direction = DashPosition.position - transform.position;
        direction.Normalize();
        dashment = direction;

        if (CurrentCoolDown <= 0)
        {
            if(Input.GetKeyDown(DashKey))
            {
                Ondash.Invoke();
                DashMechanic(DashPosition.position);
                CurrentCoolDown = DashCoolDown;
            }
        }
        else
        {
            CurrentCoolDown -= Time.deltaTime;
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





}
