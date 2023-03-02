using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SmokeEnemyWalk : EnemyWalk
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
        if (!isstoped)
        {
            rb.MovePosition((Vector2)transform.position + (direction * Time.deltaTime * CurrentSpeed));
            SkillAcive.Invoke();
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
    float normleMoveSpeed;
    public void OnSlow(bool isslow)
    {
        if(isslow)
        {
            normleMoveSpeed = MoveSpeed;
            MoveSpeed *= 0.5f;
        }
        else
        {
            MoveSpeed = normleMoveSpeed;
        }
    }

    bool isstoped = false;
    public void  stopWalk(bool stop)
    {
        isstoped = stop;
    }

    public override void provoke(Transform provoke)
    {
        player = provoke.transform;
    }
}
