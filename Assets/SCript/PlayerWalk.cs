using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public static PlayerWalk instance;


    public Rigidbody2D rb;
    public Animator animator;

    float CurrentSpeed;
    public float moveSpeed = 5f;
    Vector2 movement;

    private void Awake()
    {
        instance = this;
    }
    bool Stop;
    public void StopWalk(bool Stoped)
    {
        if(Stoped)
        {
            CurrentSpeed = 0;
            Stop = true;


        }
        else
        {
            Stop = false;
            CurrentSpeed = moveSpeed;
        }
    }

    


    void Start()
    {
        CurrentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Stop)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));

        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * CurrentSpeed * Time.fixedDeltaTime);
    }

}
