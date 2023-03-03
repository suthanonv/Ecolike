using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemWalk : MonoBehaviour
{
    Transform WalkToTransform;
    [SerializeField] float Speed;
    [SerializeField] Animator anim;
    [SerializeField] GolemAttack attack;
    Rigidbody2D rb;
    Vector2 movement;
    
    void Start()
    {
        WalkToTransform = GetPoint();
        rb = this.GetComponent<Rigidbody2D>();
    }

    bool canwalk;

    private void Update()
    {
        if(WalkToTransform != null)
        {
            attack.SetTransform(WalkToTransform);
             Vector3 direction = WalkToTransform.position - transform.position;

            direction.Normalize();
            
            movement = direction;
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("speed", movement.sqrMagnitude);
        }
        else
        {
            
            WalkToTransform = GetPoint();
        }
    }

    private void FixedUpdate()
    {
       if(WalkToTransform != null)
        {
            rb.MovePosition((Vector2)transform.position + (movement * Time.deltaTime * Speed));
        }
       else
        {
            anim.SetFloat("speed", 0);
        }
      
    }

    Transform GetPoint()
    {
        EnemyHealth[] enemy = GameObject.FindObjectsOfType<EnemyHealth>();
        Transform ShortTransform = null;
        float lastdis = 100;
        foreach(EnemyHealth i in enemy)
        {
            if(Vector2.Distance(this.transform.position,i.transform.position) < lastdis)
            {
                lastdis = Vector2.Distance(this.transform.position, i.transform.position);
                ShortTransform = i.transform;
            }
        }
        return ShortTransform;
    }

    private void OnDisable()
    {
        anim.SetFloat("speed", 0);
    }


}
