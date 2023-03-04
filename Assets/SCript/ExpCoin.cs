using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCoin : MonoBehaviour
{
    [SerializeField] float GainMuch;
    Transform MoveTo;
    Vector2 movement;
    [SerializeField] float Speed;
    Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void SetGainMuch(float neWGain)
    {
        GainMuch = neWGain;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            {
            collision.gameObject.GetComponent<ExpManage>().GainExp(GainMuch);
            Destroy(this.gameObject);
        }
    }

    public void SetPointTo(Transform newMoveTo)
    {
        MoveTo = newMoveTo;
    }

    private void Update()
    {
        if (MoveTo != null)
        {
            Vector3 diff = MoveTo.transform.position - this.transform.position;
            diff.Normalize();
            movement = diff;
        }
    }

    private void FixedUpdate()
    {
        if (MoveTo != null)
        {
            rb.MovePosition((Vector2)this.transform.position + (movement * Time.deltaTime * Speed));
        }
    }
}
