using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SmokeEnemyWalk : EnemyAttacking
{
    public float Range;

    public float attackRange;
    Animator anim;
    Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] UnityEvent SkillAcive,OffSkillAcitve;
    [SerializeField] private float MoveSpeed;
    [SerializeField] public StatHolder stat;
    float CurrentSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        MoveSpeed = stat.CharacterBaseStat.MaxSpeed;
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
     
            rb.MovePosition((Vector2)transform.position + (direction * Time.deltaTime * CurrentSpeed));
            SkillAcive.Invoke();
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


    public override void ONStatChange(bool changeToNormle)
    {
       if(changeToNormle)
        {

        }
       else
        {

        }
    }
}
