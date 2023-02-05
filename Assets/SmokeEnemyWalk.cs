using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SmokeEnemyWalk : MonoBehaviour
{
    public float Range;
    public float attackRange;
    Animator anim;
    Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] UnityEvent SkillAcive,OffSkillAcitve;
    [SerializeField] private float MoveSpeed;
    float CurrentSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        CurrentSpeed = MoveSpeed;
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;

        direction.Normalize();
        anim.SetFloat("x", direction.x);
        anim.SetFloat("y", direction.y);
        movement = direction;

    }

    private void FixedUpdate()
    {
        
            moveCharacter(movement);
          

    }
    void moveCharacter(Vector2 direction)
    {
        if (Vector2.Distance(player.transform.position, this.transform.position) <= Range)
        {
            rb.MovePosition((Vector2)transform.position + (direction * Time.deltaTime * CurrentSpeed));
            SkillAcive.Invoke();
        }
        else if(Vector2.Distance(player.transform.position, this.transform.position) > Range)
        {
            OffSkillAcitve.Invoke();
        }

    }

    public void BuffSpeed(bool Buff)
    {
        if(Buff)
        {
            CurrentSpeed = 3 * MoveSpeed;
        }
        else
        {
            CurrentSpeed = MoveSpeed;
        }
    }
}
