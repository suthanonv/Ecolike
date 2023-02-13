using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWalking : MonoBehaviour
{
 
    public Rigidbody2D rb;
    [SerializeField] Transform Point;
    [SerializeField] float WalkLimit;
    [SerializeField] Animator anim;
    float CurrentSpeed;
    public float moveSpeed = 5f;
    Vector2 movement;
    Transform Player;
    

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        CurrentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
       if(Vector2.Distance(this.transform.position,Player.transform.position) >= WalkLimit)
        {
            SwapCamera.instance.SwapToPlayer();
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vetical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("LastHorizontal", movement.x);
            anim.SetFloat("LastVertical", movement.y);

        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * CurrentSpeed * Time.fixedDeltaTime);
    }


    public void TranfromToNormlePoint()
    {
        this.transform.position = Point.transform.position;
    }

    


}
