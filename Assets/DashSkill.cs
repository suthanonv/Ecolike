using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DashSkill : MonoBehaviour
{
    public KeyCode DashKey = KeyCode.F;
    [SerializeField] float DashCoolDown = 1;
    [SerializeField] float CurrentCoolDown;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] UnityEvent Ondash, OnDashdone;
    private void Update()
    {
        if (CurrentCoolDown <= 0)
        {
            if(Input.GetKeyDown(DashKey))
            {
     
            }
        }
        else
        {

        }

    }



}
