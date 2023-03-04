using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerWalk : MonoBehaviour
{
    public static PlayerWalk instance;


    public Rigidbody2D rb;
    public RigidbodyConstraints2D rbc;
    public Animator animator;

    float CurrentSpeed;
   
    [SerializeField] PlayerStat stat;
    
    [SerializeField] StateType typeofstat;

    Vector2 movement;
    private Camera MainCam;
    
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
            CurrentSpeed = stat.GetState(typeofstat).Stat;
        }
    }

    
    public void OnSlow(bool slow)
    {
        if(slow)
        {
            CurrentSpeed = stat.GetState(typeofstat).Stat * .25f;
        }
        else
        {
            CurrentSpeed = stat.GetState(typeofstat).Stat;
        }
    }

    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        CurrentSpeed = stat.GetState(typeofstat).Stat;
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        if (!Stop)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", rotation.x);
            animator.SetFloat("Vertical", rotation.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        animator.SetFloat("LastHorizontal", rotation.x);
        animator.SetFloat("LastVertical", rotation.y);
    }

   

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * CurrentSpeed * Time.fixedDeltaTime);
    }

    public void OnWarping(bool Warp)
    { 
    }

    private void OnDisable()
    {
        animator.SetFloat("Speed", 0);
    }

    public void FreezeingSelf(bool isfreeze)
    {
        if (isfreeze)
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

   
}
