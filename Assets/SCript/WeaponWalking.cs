using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWalking : MonoBehaviour
{
    public static WeaponWalking instance;

    private void Awake()
    {
        instance = this;
    }

    public Rigidbody2D rb;
    [SerializeField] Transform Point;
    [SerializeField] float WalkLimit;
    [SerializeField] Animator anim;
    float CurrentSpeed;
    public float moveSpeed = 5f;
    Vector2 movement;
    Transform Player;
    private Camera MainCam;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        CurrentSpeed = moveSpeed;

    }

    public void slowWalk(bool slow)
    {
        if(slow)
        {
            CurrentSpeed = moveSpeed * 0.5f;
        }
        else
        {
            CurrentSpeed = moveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Vector2.Distance(this.transform.position,Player.transform.position) >= WalkLimit)
        {
            SwapCamera.instance.SwapToPlayer();
        }

        Vector3 mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
     
     anim.SetFloat("LastHorizontal", rotation.x);
     anim.SetFloat("LastVertical", rotation.y);
        

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
